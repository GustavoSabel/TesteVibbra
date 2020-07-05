using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Customers.Filters;
using VibbraTest.Domain.ValueObjects;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(VibbraContext context) : base(context, context.Customer) { }

        public Task<List<Customer>> GetAll()
        {
            return GetAll(new CustomersFilter());
        }

        public Task<List<Customer>> GetAll(CustomersFilter filter)
        {
            var query = Set.Where(x => !x.Archived);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => x.CommercialName.StartsWith(filter.Name) || x.LegalName.StartsWith(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.Cnpj))
            {
                var cnpj = new Cnpj(filter.Cnpj);
                query = query.Where(x => x.Cnpj == cnpj);
            }

            return query.ToListAsync();
        }

        public Task<Customer> GetByCnpjAsync(Cnpj cnpj)
        {
            return Set.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }
    }
}

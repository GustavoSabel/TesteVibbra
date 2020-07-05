using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAll();
        Task<List<Customer>> GetAll(Filters.CustomersFilter filter);
        Task<Customer> GetByCnpjAsync(Cnpj cnpj);
    }
}

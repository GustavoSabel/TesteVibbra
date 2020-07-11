using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.Domain.Revenues;
using VibbraTest.Domain.Revenues.Dtos;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class RevenueRepository : RepositoryBase<Revenue>, IRevenueRepository
    {
        public RevenueRepository(VibbraContext context) : base(context, context.Revenue) { }

        public Task<decimal> GetRevenueOfYearAsync(int fiscalYear)
        {
            return Set
                .Where(x => x.AccrualDate.Year == fiscalYear)
                .SumAsync(x => x.Amount);
        }

        public Task<List<RevenueByCustomerDto>> GetByCustomerAsync(int fiscalYear)
        {
            return Set
                .Where(x => x.AccrualDate.Year == fiscalYear)
                .GroupBy(x => new { x.Customer.Id, x.Customer.CommercialName })
                .Select(x => new RevenueByCustomerDto
                {
                    CustomerName = x.Key.CommercialName,
                    MonthRevenue = x.Sum(x => x.Amount)
                }).ToListAsync();
        }

        public async Task<List<RevenueByMonthDto>> GetByMonthAsync(int fiscalYear)
        {
            var lista = await Set
                .Where(x => x.AccrualDate.Year == fiscalYear)
                .GroupBy(x => x.AccrualDate.Month)
                .Select(x => new
                {
                    Month = x.Key,
                    MonthRevenue = x.Sum(x => x.Amount)
                }).ToListAsync();

            return lista.Select(x => new RevenueByMonthDto
            {
                MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month),
                MonthRevenue = x.MonthRevenue,
            }).ToList();
        }

        public Task<List<RevenueDto>> GetAll()
        {
            return Set.Select(x => new RevenueDto
            {
                Id = x.Id,
                AccrualDate = x.AccrualDate,
                Amount = x.Amount,
                Customer = x.Customer.CommercialName,
                Description = x.Description,
                InvoiceId = x.InvoiceId,
                TransactionDate  = x.TransactionDate,
            }).ToListAsync();
        }
    }
}

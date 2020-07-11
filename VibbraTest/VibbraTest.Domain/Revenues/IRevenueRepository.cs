using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Revenues.Dtos;

namespace VibbraTest.Domain.Revenues
{
    public interface IRevenueRepository : IRepository<Revenue>
    {
        Task<decimal> GetRevenueOfYearAsync(int year);
        Task<List<RevenueByMonthDto>> GetByMonthAsync(int fiscalYear);
        Task<List<RevenueByCustomerDto>> GetByCustomerAsync(int fiscalYear);
        Task<List<RevenueDto>> GetAll();
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VibbraTest.API.Dtos;
using VibbraTest.Domain.Configuration;
using VibbraTest.Domain.Revenues;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBaseVibbra
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly IConfigurationRepository _configurationRepository;

        public ReportsController(IRevenueRepository revenueRepository, IConfigurationRepository configurationRepository)
        {
            _revenueRepository = revenueRepository;
            _configurationRepository = configurationRepository;
        }

        [HttpPost("totalRevenue")]
        public async Task<TotalRevenueDto> TotalRevenue(FiscalYearFilter filter)
        {
            return new TotalRevenueDto
            {
                MaxRevenueAmount = await GetMaxRevenueAmount(),
                TotalRevenue = await _revenueRepository.GetRevenueOfYearAsync(filter.FiscalYear)
            };
        }

        [HttpPost("revenueByMonth")]
        public async Task<ListRevenueByMonthDto> RevenueByMonth(FiscalYearFilter filter)
        {
            return new ListRevenueByMonthDto
            {
                MaxRevenueAmount = await GetMaxRevenueAmount(),
                Revenue = await _revenueRepository.GetByMonthAsync(filter.FiscalYear)
            };
        }

        [HttpPost("revenueByCustomer")]
        public async Task<ListRevenueByCustomerDto> RevenueByCustomer(FiscalYearFilter filter)
        {
            return new ListRevenueByCustomerDto
            {
                MaxRevenueAmount = await GetMaxRevenueAmount(),
                Revenue = await _revenueRepository.GetByCustomerAsync(filter.FiscalYear)
            };
        }

        private async Task<decimal> GetMaxRevenueAmount()
        {
            var configuration = await _configurationRepository.GetAsync();
            return configuration.MaxRevenueAmount;
        }
    }
}

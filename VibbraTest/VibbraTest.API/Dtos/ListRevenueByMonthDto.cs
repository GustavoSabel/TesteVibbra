using System.Collections.Generic;
using VibbraTest.Domain.Revenues.Dtos;

namespace VibbraTest.API.Dtos
{
    public class ListRevenueByMonthDto
    {
        public decimal MaxRevenueAmount { get; set; }

        public List<RevenueByMonthDto> Revenue { get; set; } = new List<RevenueByMonthDto>();
    }
}

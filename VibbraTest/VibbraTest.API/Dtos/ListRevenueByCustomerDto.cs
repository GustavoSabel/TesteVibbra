using System.Collections.Generic;
using VibbraTest.Domain.Revenues.Dtos;

namespace VibbraTest.API.Dtos
{
    public class ListRevenueByCustomerDto
    {
        public decimal MaxRevenueAmount { get; set; }

        public List<RevenueByCustomerDto> Revenue { get; set; } = new List<RevenueByCustomerDto>();
    }
}

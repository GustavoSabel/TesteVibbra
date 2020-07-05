using System.Collections.Generic;

namespace VibbraTest.Domain.Customers.Dtos
{
    public class CustomerListDto
    {
        public CustomerListDto(List<CustomerDto> customers)
        {
            Customers = customers;
        }

        public int Count => Customers.Count;
        public List<CustomerDto> Customers { get; set; }
    }
}

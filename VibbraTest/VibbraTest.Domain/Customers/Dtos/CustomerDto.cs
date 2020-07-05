using System;
using System.Text;

namespace VibbraTest.Domain.Customers.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string CommercialName { get; set; }
        public string LegalName { get; set; }
    }
}

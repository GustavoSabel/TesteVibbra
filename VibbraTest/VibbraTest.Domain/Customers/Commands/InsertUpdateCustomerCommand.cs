using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Customers.Commands
{
    public class InsertUpdateCustomerCommand
    {
        [Required]
        [MaxLength(18)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(Customer.CommercialNameMaxLenght)]
        public string CommercialName { get; set; }

        [Required]
        [StringLength(Customer.LegalNameMaxLenght)]
        public string LegalName { get; set; }
    }
}

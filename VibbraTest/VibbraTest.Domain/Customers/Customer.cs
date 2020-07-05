using VibbraTest.Domain.Base;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Customers
{
    public class Customer : EntityBase
    {
        public const int CommercialNameMaxLenght = 100;
        public const int LegalNameMaxLenght = 100;

        public Cnpj Cnpj { get; set; }
        public string CommercialName { get; set; }
        public string LegalName { get; set; }
        public bool Archived { get; set; }
    }
}

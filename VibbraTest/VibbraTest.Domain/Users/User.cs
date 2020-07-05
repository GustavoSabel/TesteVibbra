using VibbraTest.Domain.Base;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Entity
{
    public class User : EntityBase
    {
        public const int NameMaxLenght = 100;
        public const int EmailMaxLenght = 100;
        public const int PasswordMaxLenght = 20;
        public const int CompanyNameMaxLenght = 100;
        public const int PhoneNumberMaxLenght = 20;

        public string Name { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public Cnpj Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

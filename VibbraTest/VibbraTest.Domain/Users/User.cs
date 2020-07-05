using VibbraTest.Domain.Base;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Entity
{
    public class User : EntityBase
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public string Password { get; set; }
        public Cnpj Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

using VibbraTest.Domain.Base;

namespace VibbraTest.Domain.Entity
{
    public class User : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
    }
}

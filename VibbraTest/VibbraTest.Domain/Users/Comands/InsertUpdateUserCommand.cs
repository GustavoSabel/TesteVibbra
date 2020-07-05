using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Users
{
    public class InsertUpdateUserCommand
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Cnpj { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}

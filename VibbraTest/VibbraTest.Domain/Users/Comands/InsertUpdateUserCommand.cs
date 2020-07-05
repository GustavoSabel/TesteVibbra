using System.ComponentModel.DataAnnotations;
using VibbraTest.Domain.Entity;

namespace VibbraTest.Domain.Users
{
    public class InsertUpdateUserCommand
    {
        [Required]
        [StringLength(User.NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.EmailMaxLenght)]
        public string Email { get; set; }

        [Required]
        [StringLength(User.PasswordMaxLenght)]
        public string Password { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 14)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(User.CompanyNameMaxLenght)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(User.PhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }
    }
}

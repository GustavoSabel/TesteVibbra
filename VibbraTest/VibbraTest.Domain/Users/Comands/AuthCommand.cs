using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Users.Comands
{
    public class AuthCommand
    {
        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}

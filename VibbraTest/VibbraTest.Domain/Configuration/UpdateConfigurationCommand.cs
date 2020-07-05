using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Configuration
{
    public class UpdateConfigurationCommand
    {
        [Required]
        public decimal MaxRevenueAmount { get; set; }
        public bool SmsNotification { get; set; }
        public bool EmailNotification { get; set; }
    }
}

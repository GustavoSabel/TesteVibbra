namespace VibbraTest.Domain.Configuration
{
    public class ConfigurationDto
    {
        public int Id { get; set; }
        public decimal MaxRevenueAmount { get; set; }
        public bool SmsNotification { get; set; }
        public bool EmailNotification { get; set; }
    }
}

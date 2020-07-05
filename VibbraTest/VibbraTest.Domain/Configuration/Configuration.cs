using VibbraTest.Domain.Base;

namespace VibbraTest.Domain.Configuration
{
    public class Configuration : EntityBase
    {
        public decimal MaxRevenueAmount { get; set; }
        public bool SmsNotification { get; set; }
        public bool EmailNotification { get; set; }
    }
}

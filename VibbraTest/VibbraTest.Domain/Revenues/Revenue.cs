using System;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Customers;

namespace VibbraTest.Domain.Revenues
{
    public class Revenue : EntityBase
    {
        public const int InvoiceIdMaxLenght = 100;
        public const int DescriptionMaxLenght = 100;

        public decimal Amount { get; set; }
        public string InvoiceId { get; set; }
        public string Description { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

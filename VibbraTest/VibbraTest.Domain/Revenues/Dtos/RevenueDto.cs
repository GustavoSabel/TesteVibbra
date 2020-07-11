using System;
using System.Text;

namespace VibbraTest.Domain.Revenues.Dtos
{
    public class RevenueDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceId { get; set; }
        public string Description { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Customer { get; set; }
    }
}

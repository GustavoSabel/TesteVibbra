using System;

namespace VibbraTest.Domain.Expenses.Dtos
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Customer { get; set; }
        public string Category { get; set; }
    }
}

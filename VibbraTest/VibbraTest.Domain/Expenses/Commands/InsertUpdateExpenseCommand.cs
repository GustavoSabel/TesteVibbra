using System;
using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Expenses.Commands
{
    public class InsertUpdateExpenseCommand
    {
        [Range(0.01, 9999999)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(Expense.DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public DateTime AccrualDate { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}

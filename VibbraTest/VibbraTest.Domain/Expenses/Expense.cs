using System;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Categories;
using VibbraTest.Domain.Customers;

namespace VibbraTest.Domain.Expenses
{
    public class Expense : EntityBase
    {
        public const int DescriptionMaxLenght = 300;

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime AccrualDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Category Category { get; set; }
    }
}

using System.Collections.Generic;

namespace VibbraTest.Domain.Expenses.Dtos
{
    public class ExpenseListDto
    {
        public ExpenseListDto(List<ExpenseDto> expenses)
        {
            Expenses = expenses;
        }

        public int Count => Expenses.Count;
        public List<ExpenseDto> Expenses { get; set; }
    }
}

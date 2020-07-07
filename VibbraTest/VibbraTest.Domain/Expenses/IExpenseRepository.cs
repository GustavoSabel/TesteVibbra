using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Expenses.Dtos;

namespace VibbraTest.Domain.Expenses
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<List<ExpenseDto>> GetAllAsync();
    }
}

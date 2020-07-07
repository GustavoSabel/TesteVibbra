using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.Domain.Expenses;
using VibbraTest.Domain.Expenses.Dtos;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(VibbraContext context) : base(context, context.Expense)
        {
        }

        public Task<List<ExpenseDto>> GetAllAsync()
        {
            return Set.Select(x => new ExpenseDto
            {
                Id = x.Id,
                Description = x.Description,
                AccrualDate = x.AccrualDate,
                Amount = x.Amount,
                TransactionDate = x.TransactionDate,
                Customer = x.Customer.CommercialName,
                Category = x.Category.Description,
            }).ToListAsync();
        }
    }
}

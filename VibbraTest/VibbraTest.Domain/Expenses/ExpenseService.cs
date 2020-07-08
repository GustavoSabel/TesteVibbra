using System.Threading.Tasks;
using VibbraTest.Domain.Categories;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Exceptions;
using VibbraTest.Domain.Expenses.Commands;

namespace VibbraTest.Domain.Expenses
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICustomerRepository _customerRepository;

        public ExpenseService(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, ICustomerRepository customerRepository)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Expense> InsertAsync(int categoryId, InsertUpdateExpenseCommand command)
        {
            var category = await _categoryRepository.GetAsync(categoryId);
            if (category == null)
                throw new EntityNotFoundException("Category");

            if (category.Archived)
                throw new BusinessException($"Category {category.Name} is already archived");

            var customer = await _customerRepository.GetAsync(command.CustomerId);
            if (customer == null)
                throw new EntityNotFoundException("Customer");

            if (customer.Archived)
                throw new BusinessException($"Customer {customer.CommercialName} is already archived");

            var expense = new Expense
            {
                Amount = command.Amount,
                AccrualDate = command.AccrualDate,
                TransactionDate = command.TransactionDate,
                Category = category,
                Customer = customer,
                Description = command.Description,
            };

            _expenseRepository.Add(expense);
            await _expenseRepository.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense> UpdateAsync(int expenseId, InsertUpdateExpenseCommand command)
        {
            var expense = await _expenseRepository.GetAsync(expenseId);
            if (expense == null)
                throw new EntityNotFoundException("Expense");

            var customer = await _customerRepository.GetAsync(command.CustomerId);
            if (customer == null)
                throw new EntityNotFoundException("Customer");

            expense.Amount = command.Amount;
            expense.AccrualDate = command.AccrualDate;
            expense.TransactionDate = command.TransactionDate;
            expense.Customer = customer;
            expense.Description = command.Description;

            await _expenseRepository.SaveChangesAsync();

            return expense;
        }

        public async Task DeleteAsync(int expenseId)
        {
            await _expenseRepository.RemoveAsync(expenseId);
            await _expenseRepository.SaveChangesAsync();
        }
    }
}

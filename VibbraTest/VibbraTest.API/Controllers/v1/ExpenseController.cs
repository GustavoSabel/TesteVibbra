using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.API.Dtos;
using VibbraTest.Domain.Expenses;
using VibbraTest.Domain.Expenses.Commands;
using VibbraTest.Domain.Expenses.Dtos;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public partial class ExpenseController : ControllerBaseVibbra
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ExpenseService _expenseService;

        public ExpenseController(IExpenseRepository expenseRepository, ExpenseService expenseService)
        {
            _expenseRepository = expenseRepository;
            _expenseService = expenseService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<ExpenseListDto>> Get()
        {
            return new ExpenseListDto(await _expenseRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<ExpenseDto>> Get(int id)
        {
            var expense = await _expenseRepository.GetAsync(id);
            if (expense == null)
                return BadRequest(new ErrorMessage("Expense not found"));
            return ConvertToDto(expense);
        }

        [HttpPost("{customerId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CreatedEntityDto>> Post(int customerId, InsertUpdateExpenseCommand command)
        {
            var expense = await _expenseService.InsertAsync(customerId, command);
            return new CreatedEntityDto(expense.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id, InsertUpdateExpenseCommand command)
        {
            await _expenseService.UpdateAsync(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id)
        {
            await _expenseService.DeleteAsync(id);
            return NoContent();
        }

        private ExpenseDto ConvertToDto(Expense expense)
        {
            return new ExpenseDto
            {
                Id = expense.Id,
                Description = expense.Description,
                AccrualDate = expense.AccrualDate,
                Amount = expense.Amount,
                TransactionDate = expense.TransactionDate,
                Customer = expense.Customer.CommercialName,
                Category = expense.Category.Name,
            };
        }
    }
}

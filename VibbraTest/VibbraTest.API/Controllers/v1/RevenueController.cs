using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.API.Dtos;
using VibbraTest.Domain.Revenues;
using VibbraTest.Domain.Revenues.Commands;
using VibbraTest.Domain.Revenues.Dtos;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public partial class RevenueController : ControllerBaseVibbra
    {
        private readonly IRevenueRepository _revenueRepository;
        private readonly RevenueService _revenueService;

        public RevenueController(IRevenueRepository revenueRepository, RevenueService revenueService)
        {
            _revenueRepository = revenueRepository;
            _revenueService = revenueService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<List<RevenueDto>>> Get()
        {
            return await _revenueRepository.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<RevenueDto>> Get(int id)
        {
            var revenue = await _revenueRepository.GetAsync(id);
            if (revenue == null)
                return BadRequest(new ErrorMessage("Revenue not found"));
            return ConvertToDto(revenue);
        }

        [HttpPost("{customerId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CreatedEntityDto>> Post(int customerId, InsertUpdateRevenueCommand command)
        {
            var revenue = await _revenueService.InsertAsync(customerId, command);
            return new CreatedEntityDto(revenue.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id, InsertUpdateRevenueCommand command)
        {
            await _revenueService.UpdateAsync(id, command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id)
        {
            await _revenueService.DeleteAsync(id);
            return NoContent();
        }

        private RevenueDto ConvertToDto(Revenue revenue)
        {
            return new RevenueDto
            {
                Id = revenue.Id,
                InvoiceId = revenue.InvoiceId,
                Description = revenue.Description,
                AccrualDate = revenue.AccrualDate,
                Amount = revenue.Amount,
                TransactionDate = revenue.TransactionDate,
                Customer = revenue.Customer.CommercialName,
            };
        }
    }
}

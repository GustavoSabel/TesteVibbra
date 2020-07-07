using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.API.Dtos;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Customers.Commands;
using VibbraTest.Domain.Customers.Dtos;
using VibbraTest.Domain.Customers.Filters;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public partial class CustomerController : ControllerBaseVibbra
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerService _customerService;

        public CustomerController(ICustomerRepository customerRepository, CustomerService customerService)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<CustomerListDto> Get([FromQuery]CustomersFilter filter)
        {
            var customer = await _customerRepository.GetAll(filter);
            return new CustomerListDto(customer.Select(x => ConvertToDto(x)).ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer == null)
                return BadRequest(new ErrorMessage($"Empresa não encontrada"));
            return ConvertToDto(customer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CreatedEntityDto>> Post(InsertUpdateCustomerCommand command)
        {
            var customer = await _customerService.InsertAsync(command);
            return new CreatedEntityDto(customer.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id, InsertUpdateCustomerCommand command)
        {
            await _customerService.UpdateAsync(id, command);
            return NoContent();
        }

        [HttpPut("{id}/archive")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Archive(int id)
        {
            await _customerService.ArchiveAsync(id);
            return NoContent();
        }

        private CustomerDto ConvertToDto(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Cnpj = customer.Cnpj?.ToString(),
                CommercialName = customer.CommercialName,
                LegalName = customer.LegalName
            };
        }
    }
}

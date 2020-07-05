using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.API.Dtos;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Users;
using VibbraTest.Domain.Users.Dtos;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public partial class UserController : ControllerBaseVibbra
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;

        public UserController(IUserRepository userRepository, UserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            var user = await _userRepository.GetAll();
            return user.Select(x => ConvertToDto(x)).ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
                return BadRequest(new ErrorMessage($"Usuário não encontrado"));
            return ConvertToDto(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CreatedEntityResult>> Post(InsertUpdateUserCommand command)
        {
            var user = await _userService.InsertAsync(command);
            return new CreatedEntityResult(user.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id, InsertUpdateUserCommand command)
        {
            await _userService.UpdateAsync(id, command);
            return NoContent();
        }

        private UserDto ConvertToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Cnpj = user.Cnpj?.ToString(),
                CompanyName = user.CompanyName,
                Email = user.Email?.ToString(),
                Nome = user.Name,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}

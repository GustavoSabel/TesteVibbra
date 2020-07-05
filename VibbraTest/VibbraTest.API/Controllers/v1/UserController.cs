using Castle.DynamicProxy.Generators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Users;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public Task<List<User>> Get() => _userRepository.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return BadRequest(new ErrorMessage($"Usuário {id} não encontrado"));
            return Ok(user);
        }
    }
}

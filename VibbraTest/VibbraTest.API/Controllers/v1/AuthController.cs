using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Users;
using VibbraTest.Domain.Users.Comands;
using VibbraTest.Domain.Users.Dtos;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AppSettings _appSettings;

        public AuthController(UserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<AuthResponse> Post(AuthCommand command)
        {
            var user = await _userService.AuthenticateAsync(command);
            return new AuthResponse
            {
                Token = generateJwtToken(user),
                User = new UserDto
                {
                    Id = user.Id,
                    Cnpj = user.Cnpj?.ToString(),
                    CompanyName = user.CompanyName,
                    Email = user.Email?.ToString(),
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber
                },
            };
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

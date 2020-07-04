using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VibbraTest.Domain.Exceptions;

namespace VibbraTest.API.Controllers.v2
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new InvalidEntityException("Campo e-mail inválido");
        }
    }
}

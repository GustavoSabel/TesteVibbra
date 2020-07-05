using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VibbraTest.Domain.Configuration;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public partial class ConfigurationController : ControllerBaseVibbra
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly ConfigurationService _configurationService;

        public ConfigurationController(IConfigurationRepository configurationRepository, ConfigurationService configurationService)
        {
            _configurationRepository = configurationRepository;
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<ConfigurationDto> Get()
        {
            return ConvertToDto(await _configurationRepository.GetAsync());
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<ConfigurationDto>> Put(UpdateConfigurationCommand command)
        {
            var configuration = await _configurationService.UpdateConfiguration(command);
            return Ok(ConvertToDto(configuration));
        }

        private ConfigurationDto ConvertToDto(Configuration configuration)
        {
            return new ConfigurationDto
            {
                Id = configuration.Id,
                EmailNotification = configuration.EmailNotification,
                MaxRevenueAmount = configuration.MaxRevenueAmount,
                SmsNotification = configuration.SmsNotification
            };
        }
    }
}

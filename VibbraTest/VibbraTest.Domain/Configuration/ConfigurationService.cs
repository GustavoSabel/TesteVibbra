using System.Threading.Tasks;

namespace VibbraTest.Domain.Configuration
{
    public class ConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<Configuration> UpdateConfiguration(UpdateConfigurationCommand command)
        {
            var configuration = await _configurationRepository.GetAsync();
            configuration.EmailNotification = command.EmailNotification;
            configuration.SmsNotification = command.SmsNotification;
            configuration.MaxRevenueAmount = command.MaxRevenueAmount;

            await _configurationRepository.SaveChangesAsync();

            return configuration;
        }
    }
}

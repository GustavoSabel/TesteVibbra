using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VibbraTest.Domain.Configuration;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class ConfigurationRepository : RepositoryBase<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(VibbraContext context) : base(context, context.Configuration)
        {
        }

        public Task<Configuration> GetAsync()
        {
            return Set.FirstOrDefaultAsync() ?? throw new System.Exception("Configuration not found");
        }
    }
}

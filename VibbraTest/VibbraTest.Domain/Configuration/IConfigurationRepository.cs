using System.Threading.Tasks;
using VibbraTest.Domain.Base;

namespace VibbraTest.Domain.Configuration
{
    public interface IConfigurationRepository : IRepository
    {
        Task<Configuration> GetAsync();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Entity;

namespace VibbraTest.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAll();
    }
}

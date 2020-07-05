using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAll();
        Task<User> GetByEmailAsync(Email email);
        Task<User> GetByEmailCnpj(Cnpj cnpj);
    }
}

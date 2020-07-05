using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Users;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(VibbraContext context) : base(context, context.User)
        {
        }

        public Task<List<User>> GetAll()
        {
            return Set.ToListAsync();
        }
    }
}

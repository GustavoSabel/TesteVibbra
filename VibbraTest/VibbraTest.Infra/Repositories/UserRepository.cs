using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Users;
using VibbraTest.Domain.ValueObjects;
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

        public Task<User> GetByEmailAsync(Email email)
        {
            return Set.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Task<User> GetByNameAsync(string name)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == name);
        }

        public Task<User> GetByEmailCnpj(Cnpj cnpj)
        {
            return Set.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }

        public Task<User> GetByNameOrEmailAsync(string nameOrEmail)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == nameOrEmail || x.Email == nameOrEmail);
        }
    }
}

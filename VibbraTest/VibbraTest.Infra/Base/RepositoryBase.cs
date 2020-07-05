using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;

namespace VibbraTest.Infra.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        protected readonly VibbraContext Context;
        protected readonly DbSet<T> Set;

        public RepositoryBase(VibbraContext context, DbSet<T> set)
        {
            Context = context;
            Set = set;
        }

        public void Add(T entity) => Set.Add(entity);

        public ValueTask<T> Get(int id) => Set.FindAsync(id);

        public Task SaveChangesAsync() => Context.SaveChangesAsync();
    }
}

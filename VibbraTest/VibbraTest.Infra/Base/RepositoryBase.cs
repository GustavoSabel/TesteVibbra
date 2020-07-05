using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.Exceptions;

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

        public ValueTask<T> GetAsync(int id) => Set.FindAsync(id);

        public async Task RemoveAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity == null)
                throw new BusinessException($"Entidade {id} não encontrada");
            Set.Remove(entity);
        }

        public void Remove(T entity)
        {
            Set.Remove(entity);
        }

        public Task SaveChangesAsync() => Context.SaveChangesAsync();
    }
}

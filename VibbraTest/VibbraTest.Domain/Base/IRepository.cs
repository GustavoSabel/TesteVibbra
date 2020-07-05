using System.Threading.Tasks;

namespace VibbraTest.Domain.Base
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    }

    public interface IRepository<T> : IRepository where T : EntityBase
    {
        ValueTask<T> GetAsync(int id);
        Task RemoveAsync(int id);
        void Remove(T entity);
        void Add(T entity);
    }
}

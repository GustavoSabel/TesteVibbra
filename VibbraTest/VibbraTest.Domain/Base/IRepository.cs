using System.Threading.Tasks;

namespace VibbraTest.Domain.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        ValueTask<T> GetAsync(int id);
        Task RemoveAsync(int id);
        void Remove(T entity);
        void Add(T entity);
        Task SaveChangesAsync();
    }
}

using System.Threading.Tasks;
using VibbraTest.Domain.Base;

namespace VibbraTest.Domain.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        ValueTask<T> Get(int id);
        void Add(T entity);
        Task SaveChangesAsync();
    }
}

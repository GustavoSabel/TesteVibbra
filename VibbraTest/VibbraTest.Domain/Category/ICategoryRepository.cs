using System.Collections.Generic;
using System.Threading.Tasks;
using VibbraTest.Domain.Base;
using VibbraTest.Domain.ValueObjects;

namespace VibbraTest.Domain.Category
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetAll(Filters.CategoryFilter filter);
        Task<Category> GetByNameAsync(string name);
    }
}

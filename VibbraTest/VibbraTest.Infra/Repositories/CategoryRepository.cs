using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.Domain.Category;
using VibbraTest.Domain.Category.Filters;
using VibbraTest.Infra.Base;

namespace VibbraTest.Infra.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(VibbraContext context) : base(context, context.Category) { }

        public Task<List<Category>> GetAll()
        {
            return GetAll(new CategoryFilter());
        }

        public Task<List<Category>> GetAll(CategoryFilter filter)
        {
            var query = Set.Where(x => !x.Archived);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => x.Name.StartsWith(filter.Name));

            return query.ToListAsync();
        }

        public Task<Category> GetByNameAsync(string name)
        {
            return Set.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}

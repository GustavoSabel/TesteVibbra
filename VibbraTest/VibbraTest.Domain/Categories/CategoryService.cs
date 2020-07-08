using System.Threading.Tasks;
using VibbraTest.Domain.Categories.Commands;
using VibbraTest.Domain.Exceptions;

namespace VibbraTest.Domain.Categories
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> InsertAsync(InsertUpdateCategoryCommand command)
        {
            command.Name = command.Name.Trim();

            var existingCategory = await _categoryRepository.GetByNameAsync(command.Name);
            if (existingCategory != null)
                throw new BusinessException($"Category {command.Name} already exists");

            var category = new Category
            {
                Name = command.Name,
                Description = command.Description,
            };
            _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(int id, InsertUpdateCategoryCommand command)
        {
            command.Name = command.Name.Trim();

            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
                throw new EntityNotFoundException("Category");

            if (category.Name != command.Name)
            {
                var existingCategory = await _categoryRepository.GetByNameAsync(command.Name);
                if (existingCategory != null)
                    throw new BusinessException($"Category {command.Name} already exists");
            }

            category.Name = command.Name;
            category.Description = command.Description;

            await _categoryRepository.SaveChangesAsync();
            return category;
        }

        public async Task ArchiveAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
                throw new EntityNotFoundException("Company");

            if (category.Archived == true)
                throw new BusinessException($"Category is already archived");

            category.Archived = true;

            await _categoryRepository.SaveChangesAsync();
        }
    }
}

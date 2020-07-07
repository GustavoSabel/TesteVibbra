using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VibbraTest.API.Dtos;
using VibbraTest.Domain.Categories;
using VibbraTest.Domain.Categories.Commands;
using VibbraTest.Domain.Categories.Dtos;
using VibbraTest.Domain.Categories.Filters;

namespace VibbraTest.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public partial class CategoryController : ControllerBaseVibbra
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryService _categoryService;

        public CategoryController(ICategoryRepository categoryRepository, CategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<CategoryListDto> Get([FromQuery]CategoryFilter filter)
        {
            var category = await _categoryRepository.GetAll(filter);
            return new CategoryListDto(category.Select(x => ConvertToDto(x)).ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
                return BadRequest(new ErrorMessage($"Categoria não encontrada"));
            return ConvertToDto(category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<ActionResult<CreatedEntityDto>> Post(InsertUpdateCategoryCommand command)
        {
            var category = await _categoryService.InsertAsync(command);
            return new CreatedEntityDto(category.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Put(int id, InsertUpdateCategoryCommand command)
        {
            await _categoryService.UpdateAsync(id, command);
            return NoContent();
        }

        [HttpPut("{id}/archive")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage))]
        public async Task<IActionResult> Archive(int id)
        {
            await _categoryService.ArchiveAsync(id);
            return NoContent();
        }

        private CategoryDto ConvertToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}

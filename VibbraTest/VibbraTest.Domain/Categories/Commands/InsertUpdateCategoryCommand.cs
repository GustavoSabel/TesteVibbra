using System.ComponentModel.DataAnnotations;

namespace VibbraTest.Domain.Categories.Commands
{
    public class InsertUpdateCategoryCommand
    {
        [Required]
        [StringLength(Category.NameMaxLenght)]
        public string Name { get; set; }

        [StringLength(Category.DescriptionMaxLenght)]
        public string Description { get; set; }
    }
}

using VibbraTest.Domain.Base;

namespace VibbraTest.Domain.Category
{
    public class Category : EntityBase
    {
        public const int NameMaxLenght = 50;
        public const int DescriptionMaxLenght = 200;

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Archived { get; set; }
    }
}

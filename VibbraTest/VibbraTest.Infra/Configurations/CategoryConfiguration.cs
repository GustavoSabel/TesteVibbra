using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Category;

namespace VibbraTest.Infra.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(Category.NameMaxLenght);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(Category.DescriptionMaxLenght);
        }
    }
}

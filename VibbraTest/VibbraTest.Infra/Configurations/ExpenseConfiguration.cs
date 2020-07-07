using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Expenses;

namespace VibbraTest.Infra.Configurations
{
    class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(Expense.DescriptionMaxLenght);
            builder.Property(x => x.Amount);
            builder.Property(x => x.AccrualDate).HasColumnType("DATE");
            builder.Property(x => x.TransactionDate).HasColumnType("DATE");
            builder.HasOne(x => x.Customer).WithMany().IsRequired();
            builder.HasOne(x => x.Category).WithMany().IsRequired();
        }
    }
}

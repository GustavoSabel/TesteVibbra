using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Revenues;

namespace VibbraTest.Infra.Configurations
{
    class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(Revenue.DescriptionMaxLenght);
            builder.Property(x => x.InvoiceId).IsRequired().HasMaxLength(Revenue.InvoiceIdMaxLenght);
            builder.Property(x => x.Amount);
            builder.Property(x => x.AccrualDate).HasColumnType("DATE");
            builder.Property(x => x.TransactionDate).HasColumnType("DATE");
            builder.HasOne(x => x.Customer).WithMany().IsRequired();
        }
    }
}

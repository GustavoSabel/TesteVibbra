using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Customers;

namespace VibbraTest.Infra.Configurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Cnpj)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Domain.ValueObjects.Cnpj(x))
                .HasColumnType("CHAR(14)");

            builder.Property(x => x.CommercialName)
                .IsRequired()
                .HasMaxLength(Customer.CommercialNameMaxLenght);

            builder.Property(x => x.LegalName)
                .IsRequired()
                .HasMaxLength(Customer.LegalNameMaxLenght);
        }
    }
}

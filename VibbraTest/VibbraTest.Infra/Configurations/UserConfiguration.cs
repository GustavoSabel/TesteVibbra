using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Entity;

namespace VibbraTest.Infra.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CompanyName).HasMaxLength(100);
            builder.Property(x => x.Cnpj).HasMaxLength(14);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
        }
    }
}

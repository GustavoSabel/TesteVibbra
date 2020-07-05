using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Entity;

namespace VibbraTest.Infra.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(User.NameMaxLenght);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(User.PasswordMaxLenght);
            builder.Property(x => x.CompanyName).HasMaxLength(User.CompanyNameMaxLenght);
            builder.Property(x => x.Cnpj)
                .HasConversion(x => x.Value, x => new Domain.ValueObjects.Cnpj(x))
                .HasColumnType("CHAR(14)");
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Domain.ValueObjects.Email(x))
                .HasMaxLength(User.EmailMaxLenght);
            builder.Property(x => x.PhoneNumber).HasMaxLength(User.PhoneNumberMaxLenght);
        }
    }
}

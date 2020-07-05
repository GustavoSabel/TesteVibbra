using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VibbraTest.Domain.Configuration;

namespace VibbraTest.Infra.Configurations
{
    class ConfigurationConfiguration : IEntityTypeConfiguration<Configuration>
    {
        public void Configure(EntityTypeBuilder<Configuration> builder)
        {
            builder.Property(x => x.EmailNotification);
            builder.Property(x => x.SmsNotification);
            builder.Property(x => x.MaxRevenueAmount);
        }
    }
}

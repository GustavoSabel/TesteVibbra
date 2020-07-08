using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using VibbraTest.Domain.Categories;
using VibbraTest.Domain.Configuration;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Entity;
using VibbraTest.Domain.Expenses;
using VibbraTest.Domain.Helpers;
using VibbraTest.Domain.Revenues;

namespace VibbraTest.Infra
{
    public class VibbraContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Revenue> Revenue { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<Expense> Expense { get; set; }

        public VibbraContext(DbContextOptions<VibbraContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SetDefaultColumnTypes(modelBuilder);

            Seed(modelBuilder);
        }

        private static void SetDefaultColumnTypes(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetColumnType() == null)
                {
                    var maxLenght = property.GetMaxLength();
                    if (maxLenght != null)
                        property.SetColumnType($"varchar({maxLenght.Value})");
                    else
                        property.SetColumnType("varchar(100)");
                }
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                if (property.GetColumnType() == null)
                    property.SetColumnType("decimal(13,4)");
            }
        }

        public static void Configurar(DbContextOptionsBuilder options, string connectionString, bool isDevelopment)
        {
            options
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();

            if (isDevelopment)
            {
                var logger = LoggerFactory.Create(builder =>
                {
                    builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
                    builder.AddConsole();
                });
                options
                    .UseLoggerFactory(logger)
                    .EnableSensitiveDataLogging();
            }
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Admin",
                Password = PasswordHelper.GenerateHash("Admin"),
            });

            modelBuilder.Entity<Configuration>().HasData(new Configuration
            {
                Id = 1,
                MaxRevenueAmount = 10000
            });
        }
    }
}

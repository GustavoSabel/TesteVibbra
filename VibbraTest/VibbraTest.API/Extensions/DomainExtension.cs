using Microsoft.Extensions.DependencyInjection;
using VibbraTest.Domain.Category;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Revenues;
using VibbraTest.Domain.Users;
using VibbraTest.Infra.Repositories;

namespace VibbraTest.API.Extensions
{
    public static class DomainExtension
    {
        public static void AddRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserService>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerService>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<CategoryService>();

            services.AddTransient<IRevenueRepository, RevenueRepository>();
            services.AddTransient<RevenueService>();
        }
    }
}

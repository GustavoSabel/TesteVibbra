﻿using Microsoft.Extensions.DependencyInjection;
using VibbraTest.Domain.Categories;
using VibbraTest.Domain.Configuration;
using VibbraTest.Domain.Customers;
using VibbraTest.Domain.Expenses;
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

            services.AddTransient<IConfigurationRepository, ConfigurationRepository>();
            services.AddTransient<ConfigurationService>();

            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<ExpenseService>();
        }
    }
}

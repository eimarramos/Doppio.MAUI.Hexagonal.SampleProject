using Domain.Repositories;
using Infrastructure.Api.CartRepository;
using Infrastructure.Api.CategoryRepository;
using Infrastructure.Api.CoffeeRepository;
using Infrastructure.Api.ShopRepository;
using Infrastructure.Config;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            string DbConnetion = $"Filename={Constants.DatabasePath}";

            // Database and interceptors

            services.AddScoped<ISaveChangesInterceptor, CartTotalInterceptor>();

            services.AddDbContext<DatabaseContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlite(DbConnetion);
            });

            // AutoMapper

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Repositories

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            // Database Initializer

            services.AddSingleton<DatabaseContextInitializer>();

            return services;
        }
    }
}

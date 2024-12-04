using ApplicationLayer.Services.CategoryService;
using ApplicationLayer.Services.ShopService;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Services

            services.AddScoped<CategoryService>();
            services.AddScoped<ShopService>();

            return services;
        }
    }
}

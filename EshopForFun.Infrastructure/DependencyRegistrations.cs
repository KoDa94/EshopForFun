using EshopForFun.AppLayer.Repositories;
using EshopForFun.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EshopForFun.Infrastructure
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}

using EshopForFun.AppLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EshopForFun.AppLayer
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterAppLayer(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}

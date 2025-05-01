using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistence;
using Shop.Infrastructure.Seeders;

namespace Shop.Infrastructure.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ShopDbConnectionString");
            services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IShopSeeder, ShopSeeder>();
        }
    }
}

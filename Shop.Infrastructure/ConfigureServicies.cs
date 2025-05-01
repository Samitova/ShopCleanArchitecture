using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistence;
using Shop.Infrastructure.Seeders;

namespace Shop.Infrastructure;
public static class ConfigureServicies
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ShopDbConnectionString");
        services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IShopSeeder, ShopSeeder>();

        return services;
    }
}

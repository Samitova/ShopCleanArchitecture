using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Contracts;
using Shop.Infrastructure.Persistence;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Seeders;

namespace Shop.Infrastructure;
public static class ConfigureServicies
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ShopDbConnectionString") ??
            throw new InvalidOperationException("Connection string ShopDbConnectionString was not found");
        services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IShopSeeder, ShopSeeder>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();

        return services;
    }
}

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shop.Application;
public static class ConfigureServicies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(ctg => 
            ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}

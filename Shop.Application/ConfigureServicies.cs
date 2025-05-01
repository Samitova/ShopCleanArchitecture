using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Mappings;
using System.Reflection;

namespace Shop.Application;
public static class ConfigureServicies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddMediatR(ctg => 
            ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}

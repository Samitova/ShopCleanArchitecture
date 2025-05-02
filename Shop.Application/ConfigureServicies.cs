using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Behaviours;
using Shop.Application.Common.Mappings;
using System.Reflection;

namespace Shop.Application;
public static class ConfigureServicies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(ctg => {
            ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
        });

        return services;
    }
}

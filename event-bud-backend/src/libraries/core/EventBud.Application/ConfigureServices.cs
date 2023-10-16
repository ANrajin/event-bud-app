using EventBud.Application.Behaviours;
using EventBud.Application.IAM.Adapters;
using EventBud.Application.IAM.Contracts;
using EventBud.Domain._Shared.IAM.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventBud.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(config =>
        {
            config.Lifetime = ServiceLifetime.Scoped;
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>));
        });

        RegisterServices(services);
        
        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IUserManagerAdapter<ApplicationUser>, UserManagerAdapter>();
        services.AddScoped<ISignInManagerAdapter<ApplicationUser>, SignInManagerAdapter>();
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace EventBud.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers(config => { config.ReturnHttpNotAcceptable = true; })
            .AddApplicationPart(typeof(ConfigureServices).Assembly);
        
        return services;
    }
}

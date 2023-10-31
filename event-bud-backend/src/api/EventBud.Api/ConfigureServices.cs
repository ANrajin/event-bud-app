using Microsoft.Extensions.DependencyInjection;

namespace EventBud.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers(config => { config.ReturnHttpNotAcceptable = true; })
            .AddApplicationPart(typeof(ConfigureServices).Assembly);

        ConfigureCors(services);
        
        return services;
    }

    private static void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("default", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE");
            });
        });
    }
}

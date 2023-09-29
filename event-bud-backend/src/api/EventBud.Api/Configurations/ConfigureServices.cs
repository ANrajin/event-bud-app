using EventBud.Application;
using EventBud.Persistence;
using Microsoft.OpenApi.Models;

namespace EventBud.Api.Configurations;

public static class ConfigureServices
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices(builder.Configuration);
        
        builder.Services.AddControllers(config => { config.ReturnHttpNotAcceptable = true; });

        builder.Services.AddEndpointsApiExplorer();

        AddSwagger(builder);

        return builder;
    }

    private static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("event-bud-api-v1", new OpenApiInfo
            {
                Title = "Event Management Application API",
                Version = "1",
                Description = "This is an events hosting platform",
                Contact = new OpenApiContact
                {
                    Name = "AN Rajin",
                    Email = "an.rajin@gmail.com",
                    Url = new Uri("https://anrajin.github.io/me")
                }
            });
        });
    }
}

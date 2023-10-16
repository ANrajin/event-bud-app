using EventBud.Api;
using EventBud.Application;
using EventBud.Application.IAM.Services;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Persistence;
using EventBud.Persistence.DBContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace EventBud.Host.Configurations;

public static class ConfigureServices
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiServices();
        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices(builder.Configuration);
        
        builder.Services.AddEndpointsApiExplorer();

        AddSwagger(builder);

        ConfigureIdentityAndAccessManagement(builder);

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

    private static void ConfigureIdentityAndAccessManagement(WebApplicationBuilder builder)
    {
        builder.Services
        .AddIdentity<ApplicationUser, Role>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddUserManager<UserManager>()
        .AddSignInManager<SignInManager>()
        .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });
    }
}

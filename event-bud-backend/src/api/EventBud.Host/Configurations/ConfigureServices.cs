using EventBud.Api;
using EventBud.Application;
using EventBud.Application.Services.IdentityAccessManagement;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Persistence;
using EventBud.Persistence.DBContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EventBud.Host.Configurations;

public static class ConfigureServices
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiServices();
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        
        builder.Services.AddEndpointsApiExplorer();

        ConfigureSwagger(builder);

        ConfigureIdentityAndAccessManagement(builder);

        return builder;
    }

    private static void ConfigureSwagger(WebApplicationBuilder builder)
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

            var securityScheme = new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authentication",
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                Description = "Please provide the bearer token to access protected end points.",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {securityScheme, Array.Empty<string>()}
            });
        });
    }

    private static void ConfigureIdentityAndAccessManagement(WebApplicationBuilder builder)
    {
        builder.Services
        .AddIdentity<ApplicationUser, Role>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddUserManager<UserManagerService>()
        .AddSignInManager<SignInManagerService>()
        .AddRoleManager<RoleManagerService>()
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

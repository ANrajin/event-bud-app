using EventBud.Application.Adapters.IdentityAccessManagement;
using EventBud.Application.Behaviours;
using EventBud.Application.Contracts.Services.IdentityAccessManagement;
using EventBud.Application.Contracts.Utilities;
using EventBud.Application.Utilities;
using EventBud.Domain._Shared.IAM.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace EventBud.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(config =>
        {
            config.Lifetime = ServiceLifetime.Scoped;
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>));
        });

        RegisterServices(services);

        ConfigureJwtAuthentication(services, configuration);

        return services;
    }

    private static IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserManagerAdapter<ApplicationUser>, UserManagerAdapter>();
        services.AddScoped<ISignInManagerAdapter<ApplicationUser>, SignInManagerAdapter>();
        services.AddScoped<IRoleManagerAdapter<ApplicationUser>, RoleManagerAdapter>();

        return services;
    }

    private static IServiceCollection ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        JwtSettings jwtSettings = new();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                options.SaveToken = true;
                options.TokenValidationParameters = options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

        return services;
    }
}

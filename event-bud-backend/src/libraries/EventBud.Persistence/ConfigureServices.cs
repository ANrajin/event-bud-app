using EventBud.Application.Contracts;
using EventBud.Application.Contracts.Repositories;
using EventBud.Persistence.DBContexts;
using EventBud.Persistence.Repositories;
using EventBud.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBud.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, 
                builder => builder.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName, "Application")));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitiator>();
        services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();
        
        #region Register Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        #endregion
        
        return services;
    }
}

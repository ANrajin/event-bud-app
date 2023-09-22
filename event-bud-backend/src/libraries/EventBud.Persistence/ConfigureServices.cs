using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Repositories;
using EventBud.Persistence.DbContexts;
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
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                builder => builder.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName, "Application")));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();
        
        #region Register Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        #endregion
        
        return services;
    }
}
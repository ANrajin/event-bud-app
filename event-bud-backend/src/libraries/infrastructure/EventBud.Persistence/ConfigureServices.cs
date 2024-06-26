﻿using EventBud.Application.Contracts.DbContexts;
using EventBud.Application.Contracts.Repositories;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Persistence.DBContexts;
using EventBud.Persistence.Interceptors;
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

        services.AddSingleton<AuditableEntityInterceptor>();
        
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var auditableEntityInterceptor = sp.GetService<AuditableEntityInterceptor>()!;

            options.UseSqlServer(connectionString,
                builder => builder.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName, "Application"))
            .AddInterceptors(auditableEntityInterceptor);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitiator>();
        services.AddScoped<IUnitOfWork, ApplicationUnitOfWork>();
        
        #region Register Repositories
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMyEventRepository, MyEventRepository>();
        #endregion
        
        return services;
    }
}

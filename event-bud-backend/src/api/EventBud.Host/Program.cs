using EventBud.Host.Configurations;
using EventBud.Persistence.DBContexts;

var builder = WebApplication.CreateBuilder(args);

var app = builder.AddServices().Build();

if (app.Environment.IsDevelopment())
{
    // ReSharper disable once ConvertToUsingDeclaration
    await using (var scope = app.Services.CreateAsyncScope())
    {
        var applicationDbContext = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContextInitiator>();
        await applicationDbContext.InitAsync();
    }
}

app.AddPipelines();

app.Run();

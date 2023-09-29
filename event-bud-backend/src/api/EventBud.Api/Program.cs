using EventBud.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

var app = builder.AddServices().Build();

app.AddPipelines();

app.Run();

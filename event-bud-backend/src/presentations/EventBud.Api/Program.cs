using EventBud.Api.Configs;

var builder = WebApplication.CreateBuilder(args);

var app = builder.AddServices().Build();

app.AddPipelines();

app.Run();
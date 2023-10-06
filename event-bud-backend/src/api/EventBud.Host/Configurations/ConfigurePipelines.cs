namespace EventBud.Host.Configurations;

public static class ConfigurePipelines
{
    public static WebApplication AddPipelines(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(options => { options.RouteTemplate = "swagger/{documentName}/swagger.json"; });
        
            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = string.Empty;
                options.SwaggerEndpoint("/swagger/event-bud-api-v1/swagger.json", "api-v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;

public static class SetupMiddlewarePipeline
{
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        // ******** Access the configuration ********
        var config = app.Configuration;

        // Configure the pipeline !! ORDER MATTERS !!
        app.UseAuthorization();
        app.UseAuthentication();
        app.MapGet("/", () =>
        {
            return "hello world";
        }).RequireAuthorization();
        return app;
    }
}

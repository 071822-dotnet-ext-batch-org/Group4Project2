using Microsoft.AspNetCore.Authentication.JwtBearer;

public static class RegisterServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        // ******* Access the configuration *******
        var config = builder.Configuration;

        // Register your dependencies
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        builder.Services.AddAuthorization();
        return builder;
    }
}

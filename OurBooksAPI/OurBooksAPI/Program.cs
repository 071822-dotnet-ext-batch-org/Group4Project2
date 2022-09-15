using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Mime;
using System;
using System.Buffers;
using System.Security.AccessControl;
using System.IO;
using BusinessLayer;
using RepositoryLayer;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Auth0.AspNetCore.Authentication;
// using Microsoft.AspNetCore.All;

var builder = WebApplication.CreateBuilder(args);

WebApplication app = WebApplication.CreateBuilder(args);
    .RegisterServices()
    .Build();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services
    .AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    .AddEndpointsApiExplorer();
    .AddSwaggerGen();
    .AddCors((options) =>
    {
        options.AddPolicy(name: "allowAll", policy =>
        {
            policy.WithOrigins("https://127.0.0.1:7010", "http://127.0.0.1:5010")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    });
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
        options.Scope = "openid profile email";
    });

//Register services here
// buiilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
// builder.Services.AddAuthorization();

//Add services to the container.
buiilder.Services.AddControllersWithViews();


var string1 = builder.Configuration["ConnectionStrings:OurBooksAPIDB"];

var app = builder.Build();

startup.Configure(app, builder.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//Register Middleware here
// app.UseAuthentication();
// app.UseAuthorization();
// app.MapGet("/", () => {
//     return "Authorized";
// }).RequireAuthorization;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("allowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.SetupMiddleware();
    .Run();

app.Run();

// // Startup.cs

// public void ConfigureServices(IServiceCollection services)
// {
//     // Some code omitted for brevity...

//     string domain = $"https://{Configuration["Auth0:Domain"]}/";
//     services.AddAuthentication(options =>
//     {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//     }).AddJwtBearer(options =>
//     {
//         options.Authority = domain;
//         options.Audience = Configuration["Auth0:ApiIdentifier"];
//         options.TokenValidationParameters = new TokenValidationParameters
//         {
//           NameClaimType = ClaimTypes.NameIdentifier
//         };
//     });
// }


// // Startup.cs

// public void Configure(IApplicationBuilder app, IHostingEnvironment env)
// {
//     // Some code omitted for brevity...

//     app.UseAuthentication();

//     app.UseMvc(routes =>
//     {
//         routes.MapRoute(
//             name: "default",
//             template: "{controller=Home}/{action=Index}/{id?}");
//     });
// }

// // HasScopeRequirement.cs

// public class HasScopeRequirement : IAuthorizationRequirement
// {
//     public string Issuer { get; }
//     public string Scope { get; }

//     public HasScopeRequirement(string scope, string issuer)
//     {
//         Scope = scope ?? throw new ArgumentNullException(nameof(scope));
//         Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
//     }
// }

// // HasScopeHandler.cs

// public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
// {
//     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
//     {
//         // If user does not have the scope claim, get out of here
//         if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
//             return Task.CompletedTask;

//         // Split the scopes string into an array
//         var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

//         // Succeed if the scope array contains the required scope
//         if (scopes.Any(s => s == requirement.Scope))
//             context.Succeed(requirement);

//         return Task.CompletedTask;
//     }
// }

// // Startup.cs

// public void ConfigureServices(IServiceCollection services)
// {
//     //...
    
//     services.AddAuthorization(options =>
//     {
//         options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
//     });

//     // register the scope authorization handler
//     services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
// }
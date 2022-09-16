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
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.All;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string allowAll = "_allowAll";
builder.Services.AddCors( options =>
{
    options.AddPolicy( name: allowAll,
    builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

//Register services here
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth0:Domain"];
        options.Audience = builder.Configuration["Auth0:Audience"];
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("ourbooks: read-write", policy =>
            policy.RequireAuthenticatedUser()
            .RequireClaim("permissions", "ourbooks: read-write"));
    });

var app = builder.Build();


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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("allowAll");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

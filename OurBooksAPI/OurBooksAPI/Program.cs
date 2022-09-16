var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string MyAllowAllOrigins = "_myAllowOrigins";
builder.Services.AddCors( options =>
{
    options.AddPolicy(name: MyAllowAllOrigins,
    builder=>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Auth0 goes here
/*
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerExtensions.AuthenticateScheme;
})



*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowAllOrigins);

app.Run();

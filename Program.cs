using api_ead;
using api_ead.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(
        "Server = localhost; initial catalog = desafio; uid = root; pwd =",
        ServerVersion.Parse("10.4.28-MariaDB")
    )
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseCors(builder =>
    builder
        .WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader()
);
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

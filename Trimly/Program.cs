using Microsoft.EntityFrameworkCore;
using Trimly.Application.Contracts;
using Trimly.Application.Services;
using Trimly.Infrastructure.Data;
using Trimly.Infrastructure.Repositories;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Base de datos
builder.Services.AddDbContext<TrimlyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();

// Servicios
builder.Services.AddScoped<ICitaService, CitaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed de datos de prueba
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TrimlyDbContext>();
    await DataSeeder.SeedAsync(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
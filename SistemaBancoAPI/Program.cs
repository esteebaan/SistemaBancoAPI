// Program.cs
using Microsoft.EntityFrameworkCore;
using SistemaBancoAPI.Data.Context;
using SistemaBancoAPI.Data.Interfaces;
using SistemaBancoAPI.Data.Repositories;
using SistemaBancoAPI.Services.Interfaces;
using SistemaBancoAPI.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de la conexi�n a la base de datos
builder.Services.AddDbContext<BancoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyecci�n de dependencias
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
builder.Services.AddScoped<ITransaccionRepository, TransaccionRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<ITransaccionService, TransaccionService>();

var app = builder.Build();

// Configuraci�n del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
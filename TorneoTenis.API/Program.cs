using TorneoTenis.API.Configuration;
using TorneoTenis.API.Middlewares.MiddlewareService.Interfaces;
using TorneoTenis.API.Middlewares.MiddlewareService;
using TorneoTenis.API.Repository.CommonQuerys;
using TorneoTenis.API.Services;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;
using TorneoTenis.API.Services.Auxiliares.Interfaces;
using TorneoTenis.API.Services.Auxiliares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTorneoTenisDbConfiguration();
builder.Services.AddScoped<IJugadorService, JugadorService>();
builder.Services.AddScoped<ITorneoService, TorneoService>();
builder.Services.AddScoped<IPartidoService, PartidoService>();
builder.Services.AddScoped<IJugadorRepository, JugadorRepository>();
builder.Services.AddScoped<IPartidoRepository, PartidoRepository>();
builder.Services.AddScoped<ITorneoRepository, TorneoRepository>();
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IDefinirGanadorService, DefinirGanadorService>();
builder.Services.AddScoped<IJugarTorneoService, JugarTorneoService>();
builder.Services.AddScoped<IExceptionService, ExceptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

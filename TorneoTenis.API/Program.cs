using TorneoTenis.API.Configuration;
using TorneoTenis.API.Middlewares.MiddlewareService.Interfaces;
using TorneoTenis.API.Middlewares.MiddlewareService;
using TorneoTenis.API.Repository.CommonQuerys;
using TorneoTenis.API.Services;
using TorneoTenis.API.Services.Interfaces;
using TorneoTenis.API.Repository.CommonQuerys.Interfaces;
using TorneoTenis.API.Services.Auxiliares.Interfaces;
using TorneoTenis.API.Services.Auxiliares;
using TorneoTenis.API.Services.Autentication;
using TorneoTenis.API.Services.Autentication.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTorneoTenisDbConfiguration();
builder.Services.AddEcnryptionOptions();
builder.Services.AddAuthenticationOptions();


builder.Services.Configure<CustomAuthenticationOptions>(
    builder.Configuration.GetSection(CustomAuthenticationOptions.Section)
);

builder.Services.ConfigureJwt(builder.Configuration);

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
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


//builder.Services.AddScoped<CustomFilter>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<ICustomAuthenticationService, CustomAuthenticationService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

using TorneoTenis.API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

namespace TorneoTenis.API.Configuration
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddTorneoTenisDbConfiguration(this IServiceCollection services) {
            IConfiguration _configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>()!;

            }

            var applicationOptions = new ApplicationOptions();

            _configuration.GetSection(ApplicationOptions.Section).Bind(applicationOptions);

            services.AddDbContext<TorneoTenisContext>(options => options.UseSqlServer(applicationOptions.ConnectionString));
        }

        public static void AddEcnryptionOptions(this IServiceCollection services)
        {
            IConfiguration _configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>()!;
            }

            var encryptionOptions = new EncryptionOptions();
            _configuration.GetSection(EncryptionOptions.Section).Bind(encryptionOptions);
            services.AddSingleton(typeof(EncryptionOptions), encryptionOptions);
        }

        public static void AddAuthenticationOptions(this IServiceCollection services)
        {
            IConfiguration _configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _configuration = serviceScope.ServiceProvider.GetService<IConfiguration>()!;
            }

            var authenticationOptions = new ApplicationOptions();
            _configuration.GetSection(ApplicationOptions.Section).Bind(authenticationOptions);
            services.AddSingleton(typeof(ApplicationOptions), authenticationOptions);
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            CustomAuthenticationOptions _authenticationOptions;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                _authenticationOptions = serviceScope.ServiceProvider.GetService<CustomAuthenticationOptions>()!;
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var _authOptions = serviceProvider.GetRequiredService<IOptions<CustomAuthenticationOptions>>().Value;

                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _authOptions.Issuer,
                    ValidAudience = _authOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.Key)),
                    ClockSkew = TimeSpan.Zero,
                };
            });
        }
    }
}

using TorneoTenis.API.Repository;
using Microsoft.EntityFrameworkCore;

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
    }
}

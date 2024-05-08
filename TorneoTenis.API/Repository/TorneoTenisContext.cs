using Microsoft.EntityFrameworkCore;
using static TorneoTenis.API.Models.Entities.Jugador;
using System.Reflection;

namespace TorneoTenis.API.Repository
{
    public class TorneoTenisContext : DbContext
    {
        public TorneoTenisContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new JugadorConfig());
        }

    }
}

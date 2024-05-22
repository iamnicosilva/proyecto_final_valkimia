using Microsoft.EntityFrameworkCore;
using static TorneoTenis.API.Models.Entities.Jugador;
using System.Reflection;
using TorneoTenis.API.Models.Entities;

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
            builder.Entity<Jugador>().HasQueryFilter(x => !x.Eliminado); //llevar esto a clase padre para que herede eliminado
            builder.Entity<Torneo>().HasQueryFilter(x => !x.Eliminado); //llevar esto a clase padre para que herede eliminado

            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new JugadorConfig());
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;

namespace TorneoTenis.API.Models.Entities
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public bool EsTorneoMasculino { get; set; }
        public bool Eliminado { get; set; }
        //public int TipoCancha { get; set; }

        public class TorneoConfig : IEntityTypeConfiguration<Torneo>
        {
            public void Configure(EntityTypeBuilder<Torneo> builder)
            {
                builder.ToTable("Torneo");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(100).IsRequired();
                builder.Property(x => x.Anio).HasColumnName("Año").HasMaxLength(4).IsRequired();
                builder.Property(x => x.Eliminado).HasColumnName("Eliminado").HasDefaultValue(false).IsRequired();


                //builder.HasData(new Torneo()
                //{
                //    Id = 1,
                //    Nombre = "Wimbledon",
                //    Año = 2026

                //},
                //new Torneo()
                //{});
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace TorneoTenis.API.Models.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [Range(0, 100)]
        public int Habilidad { get; set; }

        [Range(0, 100)]
        public int Fuerza { get; set; }

        [Range(0, 100)]
        public int Velocidad { get; set; }

        [Range(0, 100)]
        public int Reaccion {  get; set; }

        public bool EsHombre {  get; set; }
        public bool Eliminado { get; set; }

        public class JugadorConfig : IEntityTypeConfiguration<Jugador>
        {
            public void Configure(EntityTypeBuilder<Jugador> builder)
            {
                builder.ToTable("Jugador");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(100).IsRequired();
                builder.Property(x => x.Apellido).HasColumnName("Apellido").HasMaxLength(100).IsRequired();
                builder.Property(x => x.Habilidad).HasColumnName("Habilidad").HasMaxLength(3).HasDefaultValue(0).IsRequired();
                builder.Property(x => x.Fuerza).HasColumnName("Fuerza").HasMaxLength(3).HasDefaultValue(0);
                builder.Property(x => x.Velocidad).HasColumnName("Velocidad").HasMaxLength(3).HasDefaultValue(0);
                builder.Property(x => x.Reaccion).HasColumnName("Reaccion").HasMaxLength(3).HasDefaultValue(0);
                builder.Property(x => x.EsHombre).HasColumnName("EsHombre").IsRequired();
                builder.Property(x => x.Eliminado).HasColumnName("Eliminado").HasDefaultValue(false).IsRequired();

            }
        }
    }
}

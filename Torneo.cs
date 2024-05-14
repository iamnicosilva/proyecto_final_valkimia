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
        public string TipoCancha { get; set; }

        public Torneo()
        {
            // espero funke
            var random = new Random();
            int randomNumber = random.Next(1, 4); // genera de manera aleatoria el tipo de cancha

            switch (randomNumber)
            {
                case 1:
                    TipoCancha = "Césped";
                    break;
                case 2:
                    TipoCancha = "Piso";
                    break;
                case 3:
                    TipoCancha = "Polvo de Ladrillo";
                    break;
                default:
                    TipoCancha = "Desconocido";
                    break;
            }
        }
        public class TorneoConfig : IEntityTypeConfiguration<Torneo>
        {
            public void Configure(EntityTypeBuilder<Torneo> builder)
            {
                builder.ToTable("Torneo");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(100).IsRequired();
                builder.Property(x => x.Anio).HasColumnName("Año").HasMaxLength(4).IsRequired();
                builder.Property(x => x.TipoCancha).HasColumnName("TipoCancha").HasMaxLength(50).IsRequired();

            }
        }
    }
}
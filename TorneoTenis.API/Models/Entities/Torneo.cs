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
        public bool Eliminado { get; set; }
        public int IdGenero { get; set; }
        public virtual Genero genero { get; set; }

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
                builder.Property(x => x.IdGenero).HasColumnName("Genero").IsRequired();
                builder.HasOne(x => x.genero).WithMany().HasForeignKey(x => x.IdGenero);

            }
        }
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TorneoTenis.API.Models.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Genero");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Nombre).HasColumnName("Nombre").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Descripcion).HasColumnName("Descripcion").HasMaxLength(20).IsRequired();


            builder.HasData(new Genero()
            {
                Id = 1,
                Nombre = "Mujer",
                Descripcion = "Femenino"
            },
            new Genero()
            {
                Id = 2,
                Nombre = "Hombre",
                Descripcion = "Masculino"
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TorneoTenis.API.Models.Entities
{
    public class Partido
    {
        public int Id { get; set; }
        public int Etapa { get; set; } 
        public DateTime Fecha { get; set; }
        public int IdGanador { get; set; }
        public int IdPerdedor { get; set; }
        public int IdTorneo { get; set; }
        public virtual Jugador ganador { get; set; }
        public virtual Jugador perdedor { get; set; }
        public virtual Torneo torneo { get; set; }


        public class PartidoConfig : IEntityTypeConfiguration<Partido>
        {
            public void Configure(EntityTypeBuilder<Partido> builder)
            {
                builder.ToTable("Partido");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();
                builder.Property(x => x.Etapa).HasColumnName("Etapa").HasMaxLength(2).IsRequired();
                builder.Property(x => x.Fecha).HasColumnName("Fecha").IsRequired().HasMaxLength(100);

                builder.Property(x => x.IdGanador).HasColumnName("Ganador").IsRequired();
                builder.Property(x => x.IdPerdedor).HasColumnName("Perdedor").IsRequired();
                builder.Property(x => x.IdTorneo).HasColumnName("Torneo").IsRequired();

                builder.HasOne(x => x.ganador).WithMany().HasForeignKey(x => x.IdGanador).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(x => x.perdedor).WithMany().HasForeignKey(x => x.IdPerdedor).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(x => x.torneo).WithMany().HasForeignKey(x => x.IdTorneo);





                //builder.HasData(new Partido()
                //{
                //    Id = 1,
                //    Nombre = "Aula Magna",
                //    Capacidad = 50
                //},
                //new Partido()
                //{
                //    Id = 2,
                //    Nombre = "Aula Mediana",
                //    Capacidad = 40
                //},
                //new Partido()
                //{
                //    Id = 3,
                //    Nombre = "Aula chica 1",
                //    Capacidad = 25
                //},
                //new Partido()
                //{
                //    Id = 4,
                //    Nombre = "Aula chica 2",
                //    Capacidad = 25
                //});
            }
        }
    }
}

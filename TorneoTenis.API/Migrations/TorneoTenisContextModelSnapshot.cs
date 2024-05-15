﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorneoTenis.API.Repository;

#nullable disable

namespace TorneoTenis.API.Migrations
{
    [DbContext(typeof(TorneoTenisContext))]
    partial class TorneoTenisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TorneoTenis.API.Models.Entities.Jugador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Apellido");

                    b.Property<bool>("Eliminado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Eliminado");

                    b.Property<bool>("EsHombre")
                        .HasColumnType("bit")
                        .HasColumnName("EsHombre");

                    b.Property<int>("Fuerza")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Fuerza");

                    b.Property<int>("Habilidad")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Habilidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<int>("Reaccion")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Reaccion");

                    b.Property<int>("Velocidad")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("Velocidad");

                    b.HasKey("Id");

                    b.ToTable("Jugador", (string)null);
                });

            modelBuilder.Entity("TorneoTenis.API.Models.Entities.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescripcionGanador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescripcionGanador");

                    b.Property<bool>("Eliminado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Eliminado");

                    b.Property<int>("Etapa")
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasColumnName("Etapa");

                    b.Property<DateOnly>("Fecha")
                        .HasMaxLength(100)
                        .HasColumnType("date")
                        .HasColumnName("Fecha");

                    b.Property<int>("IdGanador")
                        .HasColumnType("int")
                        .HasColumnName("Ganador");

                    b.Property<int>("IdPerdedor")
                        .HasColumnType("int")
                        .HasColumnName("Perdedor");

                    b.Property<int>("IdTorneo")
                        .HasColumnType("int")
                        .HasColumnName("Torneo");

                    b.HasKey("Id");

                    b.HasIndex("IdGanador");

                    b.HasIndex("IdPerdedor");

                    b.HasIndex("IdTorneo");

                    b.ToTable("Partido", (string)null);
                });

            modelBuilder.Entity("TorneoTenis.API.Models.Entities.Torneo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("Año");

                    b.Property<bool>("Eliminado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Eliminado");

                    b.Property<bool>("EsTorneoMasculino")
                        .HasColumnType("bit")
                        .HasColumnName("Es Torneo Masculino");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Torneo", (string)null);
                });

            modelBuilder.Entity("TorneoTenis.API.Models.Entities.Partido", b =>
                {
                    b.HasOne("TorneoTenis.API.Models.Entities.Jugador", "ganador")
                        .WithMany()
                        .HasForeignKey("IdGanador")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorneoTenis.API.Models.Entities.Jugador", "perdedor")
                        .WithMany()
                        .HasForeignKey("IdPerdedor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TorneoTenis.API.Models.Entities.Torneo", "torneo")
                        .WithMany()
                        .HasForeignKey("IdTorneo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ganador");

                    b.Navigation("perdedor");

                    b.Navigation("torneo");
                });
#pragma warning restore 612, 618
        }
    }
}

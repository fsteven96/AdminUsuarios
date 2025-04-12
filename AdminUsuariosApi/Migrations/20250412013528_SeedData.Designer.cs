﻿// <auto-generated />
using AdminUsuariosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminUsuariosApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250412013528_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminUsuariosApi.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Codigo = "CAR001",
                            IdUsuarioCreacion = 1,
                            Nombre = "Programador"
                        });
                });

            modelBuilder.Entity("AdminUsuariosApi.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuarioCreacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Codigo = "DEP001",
                            IdUsuarioCreacion = 1,
                            Nombre = "Sistemas"
                        });
                });

            modelBuilder.Entity("AdminUsuariosApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int?>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdCargo = 1,
                            IdDepartamento = 1,
                            PrimerApellido = "Andrade",
                            PrimerNombre = "Steven",
                            SegundoApellido = "Salazar",
                            SegundoNombre = "Fernando",
                            Usuario = "admin"
                        });
                });

            modelBuilder.Entity("AdminUsuariosApi.Models.User", b =>
                {
                    b.HasOne("AdminUsuariosApi.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AdminUsuariosApi.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Cargo");

                    b.Navigation("Departamento");
                });
#pragma warning restore 612, 618
        }
    }
}

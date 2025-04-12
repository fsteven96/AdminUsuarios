using Microsoft.EntityFrameworkCore;
using AdminUsuariosApi.Models;

namespace AdminUsuariosApi.Data
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        // Configuración de relaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación entre User y Cargo (muchos a uno)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cargo)  
                .WithMany()             
                .HasForeignKey(u => u.IdCargo) 
                .OnDelete(DeleteBehavior.SetNull); 

            // Relación entre User y Departamento (muchos a uno)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Departamento)  
                .WithMany()                   
                .HasForeignKey(u => u.IdDepartamento) 
                .OnDelete(DeleteBehavior.SetNull);  

            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Codigo = "DEP001", Nombre = "Sistemas", Activo = true, IdUsuarioCreacion = 1 }
            );

            modelBuilder.Entity<Cargo>().HasData(
                new Cargo { Id = 1, Codigo = "CAR001", Nombre = "Programador", Activo = true, IdUsuarioCreacion = 1 }
            );

            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = 1,
                    Usuario = "admin",
                    PrimerNombre = "Steven",
                    SegundoNombre = "Fernando",
                    PrimerApellido = "Andrade",
                    SegundoApellido = "Salazar",
                    IdDepartamento = 1,
                    IdCargo = 1
                }
            );
        }
    }
}

using RegistroPedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroPedidos.Dal
{
    public class Contexto: DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"Data Source = Data/Ordenes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 1, Costo = 50, Descripcion = "Pan", Inventario = 87 });
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 2, Costo = 179, Descripcion = "Jugo de Naranja", Inventario = 53 });
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 3, Costo = 50, Descripcion = "Coca Cola", Inventario = 97 });
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 4, Costo = 42, Descripcion = "Chocolate Cortes", Inventario = 75 });
            modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 5, Costo = 317, Descripcion = "Arroz Campo", Inventario = 57 });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 1, Nombres = "Yoma" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 2, Nombres = "Rica" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 3, Nombres = "La Sirena" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 4, Nombres = "Porvenir" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 5, Nombres = "Palmares" });

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Entity;
namespace Datos
{
     public class HotelContext : DbContext
    {
         public HotelContext(DbContextOptions options):base(options)
        {
            
        } 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Producto> Productos { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .HasOne<Habitacion>().WithMany()
            .HasForeignKey(p => p.IdHabitacion);

             modelBuilder.Entity<DetalleProducto>()
            .HasOne<Producto>().WithMany()
            .HasForeignKey(p => p.idproducto);

            modelBuilder.Entity<Factura>()
            .HasOne<Cliente>().WithMany()
            .HasForeignKey(p => p.cedula);
        }
    }
}

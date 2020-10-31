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
        public DbSet<ProductoFactura> ProductoFacturas { get; set; }
        
    }
}

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
    }
}

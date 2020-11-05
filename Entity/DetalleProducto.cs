using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class DetalleProducto
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string Codigo { get; set; }

        [Column(TypeName = "int")]
        public int Cantidad { get; set; }
        
        [NotMapped]
        public Producto Producto { get; set; }
        
        [Column(TypeName = "varchar(4)")]
        public string IdProducto { get; set; }

        [NotMapped]
        public Habitacion Habitacion { get; set; }
        
        [Column(TypeName = "varchar(4)")]
        public string IdHabitacion { get; set; }
    }
}
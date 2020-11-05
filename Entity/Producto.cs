using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Producto
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdProducto { get; set; }
        
        [Column(TypeName = "varchar(12)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Tipo { get; set; }

        [Column(TypeName = "int")]
        public int Precio { get; set; }
    }
}
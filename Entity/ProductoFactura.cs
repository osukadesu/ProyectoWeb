using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ProductoFactura
    {
        [Key]
        public string IdProducto { get; set; }
        public string IdFactura { get; set; }
    }
}
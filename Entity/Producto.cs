using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Producto
    {
        [Key]
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
using Entity;

namespace ProductoModel
{
    public class ProductoInputModel
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
    }

    public class ProductoViewModel : ProductoInputModel
    {
        public ProductoViewModel(Producto producto)
        {
            IdProducto = producto.IdProducto;
            Nombre = producto.Nombre;
            Tipo = producto.Tipo;
            Precio = producto.Precio;
        }
    }
}
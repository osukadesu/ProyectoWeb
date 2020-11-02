using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class ProductoService
    {
        private readonly HotelContext _context;

        public ProductoService(HotelContext context)
        {
            _context = context;
        }
        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)

            {
                return new GuardarProductoResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaProductoResponse ConsultarTodos()
        {
            try
            {
                List<Producto> productos = _context.Productos.ToList();
                return new ConsultaProductoResponse(productos);
            }
            catch (Exception e)
            {
                return new ConsultaProductoResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Producto BuscarxIdentificacion(string idproducto)
        {
            Producto producto = _context.Productos.Find(idproducto);
            return producto;
        }

        public string Eliminar(string idproducto)
        {
            Producto producto = new Producto();
            if ((producto = _context.Productos.Find(idproducto)) != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
                return $"Se ha eliminado la persona.";
            }
            else
            {
                return $"No se encontro la persona. ";
            }
        }

        public class ConsultaProductoResponse
        {

            public ConsultaProductoResponse(List<Producto> productos)
            {
                Error = false;
                Productos = productos;
            }

            public ConsultaProductoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Producto> Productos { get; set; }
        }
        public class GuardarProductoResponse

        {

            public GuardarProductoResponse(Producto producto)

            {
                Error = false;

                Producto = producto;

            }



            public GuardarProductoResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Producto Producto { get; set; }

        }
    }
}
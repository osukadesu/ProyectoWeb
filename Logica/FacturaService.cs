using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;

namespace Logica
{
    public class FacturaService
    {
        private readonly HotelContext _context;

        public FacturaService(HotelContext context)
        {
            _context = context;
        }
        public GuardarFacturaResponse Guardar(Factura factura)
        {
            try
            {
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                return new GuardarFacturaResponse(factura);
            }
            catch (Exception e)

            {
                return new GuardarFacturaResponse($"Error de la Aplicacion: {e.Message}");
            }

        }
        public ConsultaFacturaResponse ConsultarTodos()
        {
            try
            {
                List<Factura> facturas = _context.Facturas.ToList();
                return new ConsultaFacturaResponse(facturas);
            }
            catch (Exception e)
            {
                return new ConsultaFacturaResponse($"Error en la aplicacion:  {e.Message}");
            }
        }

        public Factura BuscarxIdentificacion(string numerofactura)
        {
            Factura factura = _context.Facturas.Find(numerofactura);
            return factura;
        }

        public string Eliminar(string numerofactura)
        {
            Factura factura = new Factura();
            if ((factura = _context.Facturas.Find(numerofactura)) != null)
            {
                _context.Facturas.Remove(factura);
                _context.SaveChanges();
                return $"Se ha eliminado la persona.";
            }
            else
            {
                return $"No se encontro la persona. ";
            }
        }

        public class ConsultaFacturaResponse
        {

            public ConsultaFacturaResponse(List<Factura> facturas)
            {
                Error = false;
                Facturas = facturas;
            }

            public ConsultaFacturaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public Boolean Error { get; set; }
            public string Mensaje { get; set; }
            public List<Factura> Facturas { get; set; }
        }
        public class GuardarFacturaResponse

        {

            public GuardarFacturaResponse(Factura factura)

            {
                Error = false;

                Factura = factura;

            }



            public GuardarFacturaResponse(string mensaje)

            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }

            public string Mensaje { get; set; }

            public Factura Factura { get; set; }

        }
    }
}
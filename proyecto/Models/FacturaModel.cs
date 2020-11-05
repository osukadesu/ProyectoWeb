using System;
using Entity;

namespace FacturaModel
{
    public class FacturaInputModel
    {
        public string IdFactura { get; set; }

        public DateTime FechaFactura { get; set; }

        public int Subtotal { get; set; }

        public int Iva { get; set; }

        public int Total { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        public string Cedula { get; set; }

        public string Codigo { get; set; }

        public string IdHabitacion { get; set; }
    }

    public class FacturaViewModel : FacturaInputModel
    {
        public FacturaViewModel(Factura factura)
        {
            IdFactura = factura.IdFactura;
            FechaFactura = factura.FechaFactura;
            Cedula = factura.Cedula;
            Subtotal = factura.Subtotal;
            Iva = factura.Iva;
            Total = factura.Total;
            Cantidad = factura.Cantidad;
            FechaEntrada = factura.FechaEntrada;
            FechaSalida = factura.FechaSalida;
            Codigo = factura.Codigo;
            IdHabitacion = factura.IdHabitacion;
        }
    }
}

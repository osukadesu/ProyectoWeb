using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Factura
    {
        [Key]
        public string IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public int Subtotal { get; set; }
        public int Iva { get; set; }
        public int Total { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        
    }
}
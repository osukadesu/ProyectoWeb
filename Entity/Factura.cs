using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Factura
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdFactura { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaFactura { get; set; }
        [Column(TypeName = "int")]
        public int Subtotal { get; set; }
        [Column(TypeName = "int")]
        public int Iva { get; set; }
        [Column(TypeName = "int")]
        public int Total { get; set; }
        [Column(TypeName = "int")]
        public int Cantidad { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaEntrada { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaSalida { get; set; }
        public IList<DetalleProducto> Detalles { get; set; }
        [NotMapped]
        public Producto Producto { get; set; }
        [NotMapped]
        public Cliente Cliente { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string cedula{ get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Reserva
    {
        [Key]
        [Column(TypeName = "varchar(4)")]
        public string IdReserva { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [Column(TypeName = "varchar(4)")]
        public string Cedula { get; set; }

        [NotMapped]
        public Habitacion Habitacion { get; set; }

        [Column(TypeName = "varchar(4)")]
        public string IdHabitacion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaReserva { get; set; }

        [Column(TypeName = "decimal")]
        public int Iva { get; set; }

        [Column(TypeName = "decimal")]
        public int Total { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaEntrada { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaSalida { get; set; }
    }
}

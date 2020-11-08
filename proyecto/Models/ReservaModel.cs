using System;
using Entity;

namespace ReservaModel
{
    public class ReservaInputModel
    {
        public string IdReserva { get; set; }

        public DateTime FechaReserva { get; set; }

        public int Iva { get; set; }

        public int Total { get; set; }

        public DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        public string Cedula { get; set; }

        public string IdHabitacion { get; set; }
    }

    public class ReservaViewModel : ReservaInputModel
    {
        public ReservaViewModel(Reserva reserva)
        {
            IdReserva = reserva.IdReserva;
            FechaReserva = reserva.FechaReserva;
            Cedula = reserva.Cedula;
            Iva = reserva.Iva;
            Total = reserva.Total;
            FechaEntrada = reserva.FechaEntrada;
            FechaSalida = reserva.FechaSalida;
            IdHabitacion = reserva.IdHabitacion;
        }
    }
}

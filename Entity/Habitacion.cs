using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Habitacion
    {
        [Key]
        public string IdHabitacion { get; set; }
        public string Tipo { get; set; }
        public int NMinPersonas { get; set; }
        public string Estado { get; set; }
        public int Precio { get; set; }

    }
}
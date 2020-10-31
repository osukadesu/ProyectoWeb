using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Empleado
    {
        [Key]
        public string IdEmpleado { get; set; }
        public string Cargo { get; set; }
        public string Jornada { get; set; }
    }
}
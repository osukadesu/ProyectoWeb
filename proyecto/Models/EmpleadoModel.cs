using Entity;

namespace EmpleadoModel
{
    public class EmpleadoInputModel
    {
        public string IdEmpleado { get; set; }
        public string Jornada { get; set; }
        public string Cargo { get; set; }
    }

    public class EmpleadoViewModel : EmpleadoInputModel
    {
        public EmpleadoViewModel(Empleado empleado)
        {
            IdEmpleado = empleado.IdEmpleado;
            Jornada = empleado.Jornada;
            Cargo = empleado.Cargo;
        }
    }
}
using Entity;
using PersonaModel;

namespace EmpleadoModel
{
    public class EmpleadoInputModel:PersonaInputModel
    {
        public string IdEmpleado { get; set; }
        public string Jornada { get; set; }
        public string Cargo { get; set; }
    }

    public class EmpleadoViewModel : EmpleadoInputModel
    {
        public EmpleadoViewModel(Empleado empleado)
        {
            Cedula = empleado.Cedula;
            PrimerNombre = empleado.PrimerNombre;
            SegundoNombre = empleado.SegundoNombre;
            PrimerApellido = empleado.PrimerApellido;
            SegundoApellido = empleado.SegundoApellido;
            Edad = empleado.Edad;
            Sexo = empleado.Sexo;
            Email = empleado.Email;
            Telefono= empleado.Telefono;
            Departamento = empleado.Departamento;
            Ciudad = empleado.Ciudad;
            IdEmpleado = empleado.IdEmpleado;
            Jornada = empleado.Jornada;
            Cargo = empleado.Cargo;
        }
    }
}
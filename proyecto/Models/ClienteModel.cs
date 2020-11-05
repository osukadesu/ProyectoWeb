using Entity;
using PersonaModel;

namespace ClienteModel
{
    public class ClienteInputModel:PersonaInputModel
    {
         public string IdHabitacion { get; set; }
         public string Ppal { get; set; }
    }

    public class ClienteViewModel : ClienteInputModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            Cedula = cliente.Cedula;
            PrimerNombre = cliente.PrimerNombre;
            SegundoNombre = cliente.SegundoNombre;
            PrimerApellido = cliente.PrimerApellido;
            SegundoApellido = cliente.SegundoApellido;
            Edad = cliente.Edad;
            Sexo = cliente.Sexo;
            Email = cliente.Email;
            Telefono= cliente.Telefono;
            Departamento = cliente.Departamento;
            Ciudad = cliente.Ciudad;
            Ppal = cliente.Ppal;
            IdHabitacion = cliente.IdHabitacion;
        }
    }
}
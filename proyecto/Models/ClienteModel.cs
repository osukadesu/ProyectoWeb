using Entity;

namespace HotelNeruda.Models
{
    public class ClienteInputModel
    {
        public string Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
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
            Email = cliente.Email;
            Edad = cliente.Edad;
            Sexo = cliente.Sexo;
            Telefono = cliente.Telefono;
            Departamento = cliente.Departamento;
            Ciudad = cliente.Ciudad;
        }
    }
}
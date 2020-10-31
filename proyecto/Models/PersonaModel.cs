using Entity;

namespace PersonaModel
{
    public class PersonaInputModel
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

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel(Persona persona)
        {
            Cedula = persona.Cedula;
            PrimerNombre = persona.PrimerNombre;
            SegundoNombre = persona.SegundoNombre;
            PrimerApellido = persona.PrimerApellido;
            SegundoApellido = persona.SegundoApellido;
            Email = persona.Email;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            Telefono = persona.Telefono;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
namespace Entity
{
    public class Cliente
    {
        [Key]
        public string Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }

        public void Validaciones()
        {

        }
    }
}

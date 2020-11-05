using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Persona
    {
        [Key]
        
        [Column(TypeName = "varchar(4)")]
        public string Cedula { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string PrimerNombre { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string SegundoNombre { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string PrimerApellido { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string SegundoApellido { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Sexo { get; set; }

        [Column(TypeName = "int")]
        public int Edad { get; set; }

        [Column(TypeName = "int")]
        public int Telefono { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string Departamento { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string Ciudad { get; set; }
    }
}
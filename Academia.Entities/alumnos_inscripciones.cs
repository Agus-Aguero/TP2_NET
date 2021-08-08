using System.ComponentModel.DataAnnotations;

namespace Academia.Entities
{


    public partial class alumnos_inscripciones:Entity
    {
        [Key]
        public int id_inscripcion { get; set; }

        public int id_alumno { get; set; }

        public int id_curso { get; set; }

        [Required]
        [StringLength(50)]
        public string condicion { get; set; }

        public int? nota { get; set; }

        public virtual cursos cursos { get; set; }

        public virtual personas personas { get; set; }
    }
}

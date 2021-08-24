namespace Academia.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class docentes_cursos : Entity
    {
        [Key]
        public int id_dictado { get; set; }

        public int id_curso { get; set; }

        public int id_docente { get; set; }

        public int cargo { get; set; }

        public virtual cursos cursos { get; set; }

        public virtual personas personas { get; set; }

        [NotMapped]
        public string nombre_docente {
            get {
                return personas.apellido + " " + personas.nombre;
            } 
        }
        [NotMapped]
        public string desc_materia
        {
            get
            {
                return cursos.materias.desc_materia;
            }
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Entities
{


    public partial class cursos : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cursos()
        {
            alumnos_inscripciones = new HashSet<alumnos_inscripciones>();
            docentes_cursos = new HashSet<docentes_cursos>();

        }

        [Key]
        public int id_curso { get; set; }

        public int id_materia { get; set; }

        public int id_comision { get; set; }

        public int anio_calendario { get; set; }

        public int cupo { get; set; }

        [NotMapped]
        public string nombre_materia
        {
            get
            {
                return this.materias.desc_materia; //deber�a traer materias.desc_materia sin problemas, da error.
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alumnos_inscripciones> alumnos_inscripciones { get; set; }

        public virtual comisiones comisiones { get; set; }

        public virtual materias materias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<docentes_cursos> docentes_cursos { get; set; }


    }
}

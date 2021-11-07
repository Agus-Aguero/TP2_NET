using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Entities
{


    public partial class comisiones:Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public comisiones()
        {
            cursos = new HashSet<cursos>();
        }

        [Key]
        public int id_comision { get; set; }

        [Required]
        [StringLength(50)]
        public string desc_comision { get; set; }

        public int anio_especialidad { get; set; }

        public int id_plan { get; set; }

        public virtual planes planes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursos> cursos { get; set; }
        [NotMapped]
        public string desc_plan { get
            {
                return this.planes.desc_plan;
            }
        }
    }
}

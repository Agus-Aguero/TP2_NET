namespace Academia.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class materias:Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public materias()
        {
            cursos = new HashSet<cursos>();
        }

        [Key]
        public int id_materia { get; set; }

        [Required]
        [StringLength(50)]
        public string desc_materia { get; set; }

        public int hs_semanales { get; set; }

        public int hs_totales { get; set; }

        public int id_plan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursos> cursos { get; set; }

        public virtual planes planes { get; set; }

        [NotMapped]
        public string desc_plan { 
            get {
                return this.planes.desc_plan;
            } 
        }
    }
}

namespace Academia.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class planes:Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public planes()
        {
            comisiones = new HashSet<comisiones>();
            materias = new HashSet<materias>();
            personas = new HashSet<personas>();
        }

        [Key]
        public int id_plan { get; set; }

        [Required]
        [StringLength(50)]
        public string desc_plan { get; set; }

        public int id_especialidad { get; set; }
        [NotMapped]
        public string desc_especialidad { get { return especialidades.desc_especialidad; } }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comisiones> comisiones { get; set; }

        public virtual especialidades especialidades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<materias> materias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<personas> personas { get; set; }
    }
}

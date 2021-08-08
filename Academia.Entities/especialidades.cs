namespace Academia.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class especialidades:Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public especialidades()
        {
            planes = new HashSet<planes>();
        }

        [Key]
        public int id_especialidad { get; set; }

        [Required]
        [StringLength(50)]
        public string desc_especialidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<planes> planes { get; set; }
    }
}

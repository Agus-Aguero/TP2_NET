using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academia.Entities
{


    public partial class modulos:Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modulos()
        {
            modulos_usuarios = new HashSet<modulos_usuarios>();
        }

        [Key]
        public int id_modulo { get; set; }

        [StringLength(50)]
        public string desc_modulo { get; set; }

        [StringLength(50)]
        public string ejecuta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<modulos_usuarios> modulos_usuarios { get; set; }
    }
}

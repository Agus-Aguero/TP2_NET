namespace Academia.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class modulos_usuarios:Entity
    {
        [Key]
        public int id_modulo_usuario { get; set; }

        public int id_modulo { get; set; }

        public int id_usuario { get; set; }

        public bool? alta { get; set; }

        public bool? baja { get; set; }

        public bool? modificacion { get; set; }

        public bool? consulta { get; set; }

        public virtual modulos modulos { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}

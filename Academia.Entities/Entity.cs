using Academia.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Entities
{
    public abstract class Entity
    {

        [NotMapped]
        public virtual States State { get; set; }


        public Entity()
        {
            this.State = States.New;
        }



    }
 
}


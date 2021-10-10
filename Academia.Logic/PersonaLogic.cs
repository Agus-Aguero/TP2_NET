using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academia.Entities;
using Academia.EntityFramework;

namespace Academia.Logic
{
    public class PersonaLogic : BusinessLogic<personas>
    {
        public PersonaLogic() {
            this.repository = new PersonaRepository();
        }

    }
}

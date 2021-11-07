using Academia.Entities;
using Academia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Logic
{
    public class ComisionLogic : BusinessLogic<comisiones>
    {
        public ComisionRepository ComisionRepository { get; set; }
        public ComisionLogic()
        {
            this.repository = new ComisionRepository();
            this.ComisionRepository = new ComisionRepository();
        }
        public override IEnumerable<comisiones> GetAll()
        {
            return repository.GetAll();
        }
    }
}

using Academia.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class BusinessLogic<TEntity> where TEntity : class
    {
        public GenericRepository<TEntity> repository { get; set; }

        public BusinessLogic()
        {
            repository = new GenericRepository<TEntity>();
        }
    }
}

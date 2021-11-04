using Academia.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Logic
{
    public  interface IAppLogic<TEntity>where TEntity: Entity
    {
        TEntity Get(int ID);
        IEnumerable<TEntity> GetAll();
        void GuardarCambios(DataTable dataTable);
        void Save(TEntity entity);
        bool Delete(int ID);
        
    }
}

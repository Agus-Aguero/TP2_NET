using Academia.Entities;
using Academia.EntityFramework;
using Academia.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Logic
{
    public  class BusinessLogic<TEntity> :IAppLogic<TEntity> where TEntity :Entity
    {
        public GenericRepository<TEntity> repository { get; set; }

        public BusinessLogic()
        {
            repository = new GenericRepository<TEntity>();
        }

        public virtual TEntity Get(int ID)
        {
            return this.repository.Get(ID);
        }


        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.repository.GetAll();
        }



        public virtual void GuardarCambios(DataTable dataTable)
        {
        }


        public virtual void Save(TEntity entity)
        {
            switch (entity.State)
            {
                case States.New:
                    repository.Insert(entity);
                    break;
                case States.Deleted:
                    repository.Delete(entity);
                    break;
                case States.Modified:
                    Update(entity);
                    break;
                default:
                    break;
            }
        }
        public virtual TEntity Update(TEntity entity)
        {
            repository.Update(entity);
            return entity;

        }

        public void Delete(int ID)
        {
            repository.Delete(ID);
        }
    }
}

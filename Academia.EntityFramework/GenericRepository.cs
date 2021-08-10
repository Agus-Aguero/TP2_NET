
using Academia.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Academia.EntityFramework
{
    public class GenericRepository<TEntity> where TEntity : Entity
    {

        

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var context = new Academia())
            {
                var dbSet = context.Set<TEntity>();
                IQueryable<TEntity> query = dbSet;
                return query.ToList();
            }
          

        }

        public virtual TEntity Get(int id)
        {
            using (var context = new Academia())
            {
                var dbSet = context.Set<TEntity>();
                return dbSet.Find(id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            using (var context=new Academia())
            {
                var dbSet=context.Set<TEntity>();
                dbSet .Add(entity);
                context.SaveChanges();
                context.Dispose();

            }

        }

        public virtual void Delete(object id)
        {
            using (var context = new Academia())
            {
                var dbSet = context.Set<TEntity>();
                TEntity entityToDelete = dbSet.Find(id);
                dbSet.Remove(entityToDelete);

            }
      

        }

     

        public virtual void Update(TEntity entityToUpdate)
        {
            using (var context = new Academia())
            {
                var dbSet = context.Set<TEntity>();
                dbSet.AddOrUpdate(entityToUpdate);
                context.SaveChanges();

            }

        }


    }
}

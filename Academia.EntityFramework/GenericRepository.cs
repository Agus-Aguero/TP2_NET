
using Academia.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace Academia.EntityFramework
{
    public class GenericRepository<TEntity> where TEntity : Entity
    {
        internal Academia context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            this.context = new Academia(); // Tiene todas las entidades de la base. Es como la base
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();

        }

        public virtual TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();

        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);

        }

        public virtual void Delete(TEntity entityToDelete)
        {
            
            dbSet.Remove(entityToDelete);
            context.SaveChanges();

        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbSet.AddOrUpdate(entityToUpdate);
            context.SaveChanges();



        }


    }
}

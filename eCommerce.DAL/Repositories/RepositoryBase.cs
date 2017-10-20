using eCommerce.Contract.Repositories;
using eCommerce.DAL.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
   public abstract class RepositoryBase<TEntity> :  IRepositoryBase<TEntity> where TEntity : class
    {

        internal DataContext context;
        internal DbSet<TEntity> dbSet;


        public RepositoryBase(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
           
            
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);

        }

        //getall

        public virtual IQueryable<TEntity> GetAll()
        {

            return dbSet;

        }

        public virtual IQueryable<TEntity> GetAll(object filter)
        {

            return null;

        }
        //add


        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);

        }
        //update
        public  virtual void Update(TEntity entity)
        {

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }


        //delete
        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);

            dbSet.Remove(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }


        //commit

        public virtual void Commit()
        {

            context.SaveChanges();
        }

        public virtual void Dispose()
        {
            context.Dispose();

        }



    }
}

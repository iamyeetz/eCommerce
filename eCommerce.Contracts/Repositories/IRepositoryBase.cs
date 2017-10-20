using System.Linq;

namespace eCommerce.Contract.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Commit();
        void Delete(TEntity entity);
        void Delete(object id);
        void Dispose();
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(object filter);
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
    }
}
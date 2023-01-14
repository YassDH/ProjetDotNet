using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjetDotNet.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ProjectDBContext applicationDBContext;
        public Repository(ProjectDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public TEntity Get(Guid id)
        {
            return applicationDBContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return applicationDBContext.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return applicationDBContext.Set<TEntity>().Where(predicate);
        }
        public bool Add(TEntity entity)
        {
            try
            {
                applicationDBContext.Set<TEntity>().Add(entity);
                return true;
            }catch( Exception e)
            {
                throw e;
            }
        }
        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                applicationDBContext.Set<TEntity>().AddRange(entities);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Remove(TEntity entity)
        {
            try
            {
                applicationDBContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                applicationDBContext.Set<TEntity>().RemoveRange(entities);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Expression<Func<TEntity, bool>> predicate, TEntity entity)
        {
            applicationDBContext.Attach(entity);
            applicationDBContext.Entry(entity).State = EntityState.Modified;
        }
    }

}

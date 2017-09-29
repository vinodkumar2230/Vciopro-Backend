using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal vCIOPRoEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(vCIOPRoEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {

            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        //public virtual IEnumerable<Organisation> GetAllOrg()
        //{
        //    var query = (from result in context.Organisations
        //                                 where result.isDeleted == true
        //                 select result).ToList();
        //    return query;
        //}
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual state GetStateByID(int id)
        {
            var user = context.states.FirstOrDefault(c => c.countryid == id);

            return user;


        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void AddOrUpdate(Expression<Func<TEntity, object>> identifierExpression, params TEntity[] entitiesToUpdate)
        {
            //dbSet.AddOrUpdate(identifierExpression, entitiesToUpdate);
        }

    }
}

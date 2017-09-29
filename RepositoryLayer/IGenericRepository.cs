using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepositoryLayer
{

    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        TEntity GetByID(object id);
        state GetStateByID(int id);
        void Insert(TEntity entity);
        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        void AddOrUpdate(Expression<Func<TEntity, object>> identifierExpression, params TEntity[] entitiesToUpdate);

    }
}

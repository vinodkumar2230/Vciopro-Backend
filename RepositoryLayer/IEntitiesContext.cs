using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace RepositoryLayer
{

    public interface IEntitiesContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbChangeTracker ChangeTracker { get; }

        Database Database { get; }

        //
        // Summary:
        //     Gets a System.Data.Entity.Infrastructure.DbEntityEntry object for the given
        //     entity providing access to information about the entity and the ability to
        //     perform actions on the entity.
        //
        // Parameters:
        //   entity:
        //     The entity.
        //
        // Returns:
        //     An entry for the entity.
        DbEntityEntry Entry(object entity);

        //
        // Summary:
        //     Gets a System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> object for
        //     the given entity providing access to information about the entity and the
        //     ability to perform actions on the entity.
        //
        // Parameters:
        //   entity:
        //     The entity.
        //
        // Type parameters:
        //   TEntity:
        //     The type of the entity.
        //
        // Returns:
        //     An entry for the entity.
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new();

        int SaveChanges();

        void Dispose();
    }
}

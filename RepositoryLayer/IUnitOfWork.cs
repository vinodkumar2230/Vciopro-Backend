using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer
{
    /// <summary>
    /// Generic version of Unit Of Work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves Context changes.
        /// </summary>
        void Save();

        /// <summary>
        /// Gets repository Instance.
        /// </summary>
        /// <typeparam name="T">Type to get instance for.</typeparam>
        /// <returns>Generic Repository Implementation for the given generic type.</returns>
        IGenericRepository<T> GetRepositoryInstance<T>() where T : class, new();

        
        //void Dispose(); => This is already therein parent interface
    }
}

using System;
using CoreEntities.Domain;
using System.Data.Entity.Infrastructure;

namespace RepositoryLayer
{
    /// <summary>
    /// Unit of work implementation for having single instance of context and doing DB operation as transaction
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private vCIOPRoEntities _context;

        public UnitOfWork(vCIOPRoEntities context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepositoryInstance<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
        }
        public DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(sql, parameters);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IGenericRepository<Organisation> _organisationRepository;
        IGenericRepository<Country> _countryRepository;
        IGenericRepository<state> _stateRepository;
        public IGenericRepository<Country> CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                {
                    _countryRepository = new GenericRepository<Country>(_context);
                }

                return _countryRepository;
            }
        }
        public IGenericRepository<state> StateRepository
        {
            get
            {
                if (_stateRepository == null)
                {
                    _stateRepository = new GenericRepository<state>(_context);
                }

                return _stateRepository;
            }
        }
        public IGenericRepository<Organisation> OrganisationRepository
        {
            get
            {
                if (_organisationRepository == null)
                {
                    _organisationRepository = new GenericRepository<Organisation>(_context);
                }

                return _organisationRepository;
            }
        }

    }
}
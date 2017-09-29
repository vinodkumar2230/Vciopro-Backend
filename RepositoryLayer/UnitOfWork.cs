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
        IGenericRepository<Location> _locationRepository;
        IGenericRepository<Configuration> _configRepository;
        IGenericRepository<Contact> _contactRepository;
        IGenericRepository<ContactEmail> _contact1Repository;
        IGenericRepository<ContactPhone> _contact2Repository;
        IGenericRepository<Password> _passwordRepository;
        #region "Password Repository"
        public IGenericRepository<Password> PasswordRepository
        {
            get
            {
                if (_passwordRepository == null)
                {
                    _passwordRepository = new GenericRepository<Password>(_context);
                }

                return _passwordRepository;
            }
        }
        #endregion
        public IGenericRepository<Configuration> ConfigRepository
        {
            get
            {
                if (_configRepository == null)
                {
                    _configRepository = new GenericRepository<Configuration>(_context);
                }

                return _configRepository;
            }
        }
        public IGenericRepository<ContactEmail> Contact1Repository
        {
            get
            {
                if (_contact1Repository == null)
                {
                    _contact1Repository = new GenericRepository<ContactEmail>(_context);
                }

                return _contact1Repository;
            }
        }
        public IGenericRepository<ContactPhone> Contact2Repository
        {
            get
            {
                if (_contact2Repository == null)
                {
                    _contact2Repository = new GenericRepository<ContactPhone>(_context);
                }

                return _contact2Repository;
            }
        }
        public IGenericRepository<Contact> ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new GenericRepository<Contact>(_context);
                }

                return _contactRepository;
            }
        }
        public IGenericRepository<Location> LocationRepository
        {
            get
            {
                if (_locationRepository == null)
                {
                    _locationRepository = new GenericRepository<Location>(_context);
                }

                return _locationRepository;
            }
        }
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
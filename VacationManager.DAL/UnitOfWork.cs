using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.DAL.Contracts;
using VacationManager.DAL.Repositories;
using VacationManager.Data.Contracts;

namespace VacationManager.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;
        private readonly List<object> _repositories = new List<object>();

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _context.Configuration.ProxyCreationEnabled = true;
            _context.Configuration.LazyLoadingEnabled = true;
        }

        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            var repo = (IBaseRepository<T>)_repositories.SingleOrDefault(r => r is IBaseRepository<T>);
            if (repo == null)
            {
                _repositories.Add(repo = new EntityRepository<T>(_context));
            }
            return repo;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public bool AutoDetectChanges
        {
            get { return _context.Configuration.AutoDetectChangesEnabled; }
            set { _context.Configuration.AutoDetectChangesEnabled = value; }
        }

        public List<T> ExecuteStoredProcedure<T>(string procedureName)
        {
            return _context.Database.SqlQuery<T>(string.Format("exec {0}", procedureName), new object[0]).ToList();
        }

        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
            }
            _disposed = true;
        }

        #endregion
    }
}

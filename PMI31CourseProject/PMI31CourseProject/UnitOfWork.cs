using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using ProjectDatabase;

namespace DAL
{
    /// <summary>
    /// class UnitOfWork
    /// </summary>
    /// <typeparam name="T">type of table</typeparam>
    public class UnitOfWork<T>:IDisposable where T : class
    {
        /// <summary>
        /// Enitity of database
        /// </summary>
        private Course_ProjectEntities _context;

        /// <summary>
        /// Connect repository
        /// </summary>
        private ConnectRepository<T> _contactRepository;

        /// <summary>
        /// Initialize a new instance of the <see cref="UnitOfWork"/> class
        /// </summary>
        public UnitOfWork()
        {
            _context = new Course_ProjectEntities();
        }

        /// <summary>
        /// Gets or sets contactRepository
        /// </summary>
        public ConnectRepository<T> ContactRepository
        {
            get
            {

                if (this._contactRepository == null)
                {
                    this._contactRepository = new ConnectRepository<T>(_context);
                }
                return _contactRepository;
            }
        }

        /// <summary>
        /// Save change
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// is diposed
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Resetting unmanaged resources
        /// </summary>
        /// <param name="disposing">is disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Resetting unmanaged resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

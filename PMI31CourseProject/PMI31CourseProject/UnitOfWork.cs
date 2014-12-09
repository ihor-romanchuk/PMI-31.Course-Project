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
    public class UnitOfWork<T>:IDisposable where T : class
    {
        private Course_ProjectEntities _context;
        private ConnectRepository<T> _contactRepository;

        public UnitOfWork()
        {
            _context = new Course_ProjectEntities();
        }
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
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool _disposed = false;
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject;
using PMI31CourseProject.Repository;

namespace DAL
{
    public class UnitOfWork<T> : IDisposable where T : class
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
    }
}

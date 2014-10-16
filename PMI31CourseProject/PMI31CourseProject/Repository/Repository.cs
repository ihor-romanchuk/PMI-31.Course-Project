using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Configuration;

namespace PMI31CourseProject.Repository
{
    class Repository<T> where T: class
    {
        private Course_ProjectEntities dataContext;
        private DbSet<T> bdSet;

        public Repository(Course_ProjectEntities context)
        {
            this.dataContext = context;
            this.bdSet = context.Set<T>();
        }

        public void Add(T element)
        {
            this.bdSet.Add(element);
        }
    }
}

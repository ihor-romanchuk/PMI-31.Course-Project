using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMI31CourseProject.Repository
{
    public class ConnectRepository<T> : Repository<T> where T : class
    {
        public ConnectRepository(Course_ProjectEntities1 context)
            : base(context)
        {
        }
    }
}

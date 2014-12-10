using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabase;

namespace PMI31CourseProject.Repository
{
    /// <summary>
    /// class ConnectRepository
    /// </summary>
    /// <typeparam name="T">type of table</typeparam>
    public class ConnectRepository<T> : Repository<T> where T : class
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="ConnectRepository{T}"/> class
        /// </summary>
        /// <param name="context"></param>
        public ConnectRepository(Course_ProjectEntities context)
            : base(context)
        {
        }
    }
}

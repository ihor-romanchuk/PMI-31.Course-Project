using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using System.Linq.Expressions;
using ProjectDatabase;

namespace PMI31CourseProject.Repository
{
    /// <summary>
    /// class Repository
    /// </summary>
    /// <typeparam name="T">Random class.</typeparam>
    public class Repository<T> where T: class
    {
        /// <summary>
        /// Entity of database
        /// </summary>
        private Course_ProjectEntities dataContext;

        /// <summary>
        /// database set
        /// </summary>
        private DbSet<T> dbSet;

        /// <summary>
        /// Initialize a new instance of the <see cref="Repository{T}"/> class
        /// </summary>
        /// <param name="context">context of database</param>
        public Repository(Course_ProjectEntities context)
        {
            this.dataContext = context;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// add to database
        /// </summary>
        /// <param name="element">new element</param>
        public virtual void Add(T element)
        {
            this.dbSet.Add(element);
        }

        /// <summary>
        /// remove from database
        /// </summary>
        /// <param name="entity">element to remove</param>
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <summary>
        /// get element by id
        /// </summary>
        /// <param name="id">id of element</param>
        /// <returns>result element</returns>
        public virtual T GetById(long id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// get element by id
        /// </summary>
        /// <param name="id">id of element</param>
        /// <returns>result element</returns>
        public virtual T GetById(string id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// get all element from table
        /// </summary>
        /// <returns>all elements from table</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// get element by predicate
        /// </summary>
        /// <param name="predicat">predicate</param>
        /// <returns>result elements</returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicat)
        {
            return dbSet.Where(predicat).ToList();
        }
    }
}

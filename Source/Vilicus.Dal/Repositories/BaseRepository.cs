
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Vilicus.Dal.Repositories
{
    /// <summary>
    /// Base Repository
    /// 
    /// Override the base methods as needed by declaring the same method as new, e.g.: public new EntityName Get(int id) { ... }
    /// Modified from: https://github.com/CypressNorth/.NET-EF6-GenericRepository
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public abstract class BaseRepository<TObject> where TObject : class
    {
        protected DbContext _context;

        /// <summary>
        /// The contructor requires an open DataContext to work with
        /// </summary>
        /// <param name="context">An open DataContext</param>
        public BaseRepository(DbContext context)
        {
            this._context = context;
        }

        /*
        private IQueryable<TObject> IncludeMultiple<T>(this IQueryable<TObject> query, params Expression<Func<TObject, object>>[] includes)
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
        */

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public TObject Get(int id)
        {
            return _context.Set<TObject>().Find(id);
        }

        /// <summary>
        /// Returns a single object with a primary key of the provided id, and include any given related entities
        /// -> Not sure if this actually works...
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public TObject Get(int id, params Expression<Func<TObject, object>>[] includes)
        {
            DbSet<TObject> entityInstance = _context.Set<TObject>();

            foreach (var expression in includes)
            {
                entityInstance.Include(expression);
            }

            return entityInstance.Find(id);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <returns>An IEnumerable of every object in the database</returns>
        public IEnumerable<TObject> GetAll()
        {
            return _context.Set<TObject>().ToList();
        }

        /// <summary>
        /// Returns a single object which matches the provided expression. If there are multiple results, the first result is returned.
        /// If there are no results, null is returned.
        /// </summary>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter or null.</returns>
        public TObject Find(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().FirstOrDefault(match);
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An IEnumerable of object which match the expression filter</returns>
        public IEnumerable<TObject> FindAll(Expression<Func<TObject, bool>> match)
        {
            return _context.Set<TObject>().Where(match).ToList();
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public TObject Add(TObject t)
        {
            if (t != null)
            {
                _context.Set<TObject>().Add(t);
                _context.SaveChanges();
            }

            return t;
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public IEnumerable<TObject> AddRange(IEnumerable<TObject> tList)
        {
            if (tList != null)
            {
                foreach (TObject t in tList)
                {
                    _context.Set<TObject>().Add(t);
                }

                _context.SaveChanges();
            }

            return tList;
        }

        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <param name="t">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public TObject Update(TObject t, int key)
        {
            TObject existing = null;

            if (t != null && key > 0)
            {
                existing = _context.Set<TObject>().Find(key);

                _context.Entry(existing).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }

            return existing;
        }

        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <param name="t">The object to delete</param>
        public void Delete(TObject t)
        {
            if (t != null)
            {
                _context.Set<TObject>().Remove(t);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <returns>The count of the number of objects</returns>
        public int Count()
        {
            return _context.Set<TObject>().Count();
        }
    }
}

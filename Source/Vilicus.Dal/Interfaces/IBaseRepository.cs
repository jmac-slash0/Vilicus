using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Vilicus.Dal.Interfaces
{
    public interface IBaseRepository<TObject> where TObject : class
    {
        TObject Get(int id);

        TObject Get(int id, params Expression<Func<TObject, object>>[] includes);

        IEnumerable<TObject> GetAll();

        TObject Find(Expression<Func<TObject, bool>> target);

        IEnumerable<TObject> FindAll(Expression<Func<TObject, bool>> target);

        TObject Add(TObject t);

        IEnumerable<TObject> AddRange(IEnumerable<TObject> tList);

        TObject Update(TObject t, int key);

        void Delete(TObject t);

        int Count();
    }
}

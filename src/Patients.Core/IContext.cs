using System;
using System.Linq;
using System.Linq.Expressions;

namespace Patients.Core {
    public interface IContext<T> : IDisposable
        where T: class {
        T CreateEntity();
        void AddEntity(T entity);
        void RemoveEntity(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void SaveContextChanges();
    }
}

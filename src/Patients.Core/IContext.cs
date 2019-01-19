using System;

namespace Patients.Core {
    public interface IContext<T> : IDisposable
        where T: class {
        T CreateEntity();
        void AddEntity(T entity);
        void RemoveEntity(T entity);
        void SaveContextChanges();
    }
}

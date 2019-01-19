using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Core {
    public class BaseDBRequest<TModel, TRequest, TResponse> : IDBRequest<TModel, TResponse> 
        where TModel : class {
        public TModel Model { get; set; }
        public TRequest Data { get; set; }
        public IContext<TModel> Context { get; set; }
    }
}

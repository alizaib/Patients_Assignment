using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.Core {
    public interface IDBRequest<TModel, TResponse> : IRequest<TResponse> 
        where TModel : class {
        TModel Model { get; set; }
        IContext<TModel> Context { get; set; }
    }
}

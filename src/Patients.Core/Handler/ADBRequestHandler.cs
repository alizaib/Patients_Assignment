using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Patients.Core {
    public abstract class ADBRequestHandler<TModel, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IDBRequest<TModel, TResponse>
        where TModel : class {

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken) {
            return HandleAsync(request, cancellationToken);
        }
        public abstract Task<TResponse> HandleAsync(TRequest req, CancellationToken cancellationToken);
    }
}

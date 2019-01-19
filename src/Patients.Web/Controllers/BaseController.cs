using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patients.Core;

namespace Patients.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T> : ControllerBase
        where T : class {

        protected readonly IContext<T> Context;
        protected readonly IMediator Mediator;
        public BaseController(IContext<T> context, IMediator mediator) {
            Context = context;
            Mediator = mediator;
        }
        protected async Task<TResponse> SendAsync<TCommand, TRequest, TResponse>(TRequest req)
            where TCommand : BaseDBRequest<T, TRequest, TResponse>, new() {

            var command = new TCommand();
            command.Context = Context;
            command.Data = req;
            var cancellationToken = HttpContext.RequestAborted;

            return await Mediator.Send(command);

            //return Task.FromResult<TResponse>(default(TResponse));
        }
    }
}
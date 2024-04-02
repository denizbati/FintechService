using Autofac;
using FintechService.ApiContract;
using MediatR;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.Container.Decorator
{
    public abstract class DecoratorBase<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResponseBaseModel where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);


        protected MethodBase GetHandlerMethodInfo()
        {
            var handler = Bootstrapper.Container.Resolve<IRequestHandler<TRequest, TResponse>>();
            return handler?.GetType().GetMethod("Handle");
        }
    }
}
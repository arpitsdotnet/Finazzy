using Finazzy.Domain.Entities.Base;
using MediatR;

namespace Finazzy.Application.Abstractions.Messaging
{

    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}

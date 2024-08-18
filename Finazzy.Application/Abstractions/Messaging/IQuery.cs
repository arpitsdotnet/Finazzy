using Finazzy.Domain.Entities.Base;
using MediatR;

namespace Finazzy.Application.Abstractions.Messaging;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

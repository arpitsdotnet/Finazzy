using Finazzy.Users.Domain.Entities;
using MediatR;

namespace Finazzy.Users.Application.Abstractions.Messaging;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}

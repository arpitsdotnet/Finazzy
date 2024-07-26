using Finazzy.Users.Domain.Entities;
using MediatR;

namespace Finazzy.Users.Application.Abstractions.Messaging;


public interface ICommand : IRequest<Result>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

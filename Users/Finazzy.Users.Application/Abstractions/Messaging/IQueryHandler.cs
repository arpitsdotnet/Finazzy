using Finazzy.Users.Domain.Entities;
using MediatR;

namespace Finazzy.Users.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, Result>
    where TQuery : IQuery<Result>
{
}

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
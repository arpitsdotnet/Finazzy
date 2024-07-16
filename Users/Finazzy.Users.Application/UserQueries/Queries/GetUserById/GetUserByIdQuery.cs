using System;
using Finazzy.Users.Application.Abstractions.Messaging;

namespace Finazzy.Users.Application.UserQueries.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
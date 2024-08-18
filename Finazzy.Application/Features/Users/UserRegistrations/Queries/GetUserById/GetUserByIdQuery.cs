using System;
using Finazzy.Application.Abstractions.Messaging;

namespace Finazzy.Application.Features.Users.UserRegistrations.Queries.GetUserById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
using System;

namespace Finazzy.Application.Features.Users.UserRegistrations.Queries.GetUserById;

public sealed record UserResponse(Guid Id, string Username, string Password, DateTime RegisteredOn);
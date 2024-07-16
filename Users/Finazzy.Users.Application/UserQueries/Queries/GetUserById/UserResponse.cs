using System;

namespace Finazzy.Users.Application.UserQueries.Queries.GetUserById;

public sealed record UserResponse(Guid Id, string Username, string Password, DateTime RegisteredOn);
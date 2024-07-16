using System;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUser;

public sealed record CreateUserRequest(string Username, string Password);
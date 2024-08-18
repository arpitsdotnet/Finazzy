using System;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.CreateUser;

public sealed record CreateUserRequest(string Username, string Password);
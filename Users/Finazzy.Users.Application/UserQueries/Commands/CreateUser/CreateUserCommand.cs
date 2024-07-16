using System;
using Finazzy.Users.Application.Abstractions.Messaging;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUser;

public sealed record CreateUserCommand(string Username, string Password) : ICommand<Guid>;

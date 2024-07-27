using System;
using Finazzy.Users.Application.Abstractions.Messaging;
using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUser;

public sealed record CreateUserCommand(string Username, string Password) : ICommand<Result<Guid>>;

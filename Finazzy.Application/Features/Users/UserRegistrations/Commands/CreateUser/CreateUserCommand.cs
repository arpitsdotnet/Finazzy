using System;
using Finazzy.Application.Abstractions.Messaging;
using Finazzy.Domain.Entities.Base;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.CreateUser;

public sealed record CreateUserCommand(string Username, string Password) : ICommand<Result<Guid>>;

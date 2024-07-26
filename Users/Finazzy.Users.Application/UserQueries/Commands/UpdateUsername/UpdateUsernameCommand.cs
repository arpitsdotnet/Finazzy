using System;
using Finazzy.Users.Application.Abstractions.Messaging;
using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Application.UserQueries.Commands.UpdateUsername;

public sealed record UpdateUsernameCommand(Guid Id, string Username) : ICommand<User>;
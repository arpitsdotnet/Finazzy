using System;
using Finazzy.Application.Abstractions.Messaging;
using Finazzy.Domain.Entities.Users;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.UpdateUsername;

public sealed record UpdateUsernameCommand(Guid Id, string Username) : ICommand<UserRegistration>;
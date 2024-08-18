using System;
using Finazzy.Application.Abstractions.Messaging;
using Finazzy.Domain.Entities.Users;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.CreateUserByMobile;

public sealed record CreateUserByMobileCommand(Mobile MobileNumber, string OneTimePassword) : ICommand<Guid>;

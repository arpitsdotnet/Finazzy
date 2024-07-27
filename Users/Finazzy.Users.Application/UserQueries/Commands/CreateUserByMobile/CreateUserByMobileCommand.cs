using System;
using Finazzy.Users.Application.Abstractions.Messaging;
using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUserByMobile;

public sealed record CreateUserByMobileCommand(Mobile MobileNumber, string OneTimePassword) : ICommand<Guid>;

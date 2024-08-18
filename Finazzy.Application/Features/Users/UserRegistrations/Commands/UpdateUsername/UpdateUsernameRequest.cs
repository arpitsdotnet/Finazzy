using System;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.UpdateUsername;

public sealed record UpdateUsernameRequest(Guid Id, string Username);

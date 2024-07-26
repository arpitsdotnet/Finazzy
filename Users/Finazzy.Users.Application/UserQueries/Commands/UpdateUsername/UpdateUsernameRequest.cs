using System;

namespace Finazzy.Users.Application.UserQueries.Commands.UpdateUsername;

public sealed record UpdateUsernameRequest(Guid Id, string Username);

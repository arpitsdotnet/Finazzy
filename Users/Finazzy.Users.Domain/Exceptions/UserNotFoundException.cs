using Finazzy.Users.Domain.Exceptions.Base;
using System;

namespace Finazzy.Users.Domain.Exceptions;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid userId)
        : base($"The user with identifier {userId} was not found.")
    {
    }
    public UserNotFoundException(string username)
        : base($"The user with username {username} was not found.")
    {
    }
}

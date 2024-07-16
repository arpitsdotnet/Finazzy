using Finazzy.Users.Domain.Exceptions.Base;
using System;

namespace Finazzy.Users.Domain.Exceptions;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid userId)
        : base($"The user with identifier {userId} was not found.")
    {
    }
}

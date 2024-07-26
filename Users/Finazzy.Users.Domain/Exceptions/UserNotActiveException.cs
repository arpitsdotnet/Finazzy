using Finazzy.Users.Domain.Exceptions.Base;

namespace Finazzy.Users.Domain.Exceptions;

public sealed class UserNotActiveException : NotActiveException
{
    public UserNotActiveException(string username) 
        : base($"The user with username {username} is not active, please contact administration.")
    {
    }
}

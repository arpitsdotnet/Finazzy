using Finazzy.Domain.Exceptions.Base;

namespace Finazzy.Domain.Exceptions.Users;

public sealed class UserNotActiveException : NotActiveException
{
    public UserNotActiveException(string username)
        : base($"The user with username {username} is not active, please contact administration.")
    {
    }
}

using Finazzy.Users.Domain.Exceptions.Base;

namespace Finazzy.Users.Domain.Exceptions;

public sealed class UsernameAndPasswordNotMatchedException : NotMatchedException
{
    public UsernameAndPasswordNotMatchedException(string username)
        : base($"The user with username {username} does not matched with the given password.")
    {
    }
}

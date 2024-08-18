using Finazzy.Domain.Exceptions.Base;

namespace Finazzy.Domain.Exceptions.Users;

public sealed class UsernameAndPasswordNotMatchedException : NotMatchedException
{
    public UsernameAndPasswordNotMatchedException(string username)
        : base($"The user with username {username} does not matched with the given password.")
    {
    }
}

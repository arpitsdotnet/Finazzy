using System;

namespace Finazzy.Users.Domain.Exceptions.Base;

public class NotMatchedException : Exception
{
    public NotMatchedException(string message) 
        : base(message)
    {
    }
}

using System;

namespace Finazzy.Users.Domain.Exceptions.Base;

public class NotActiveException : Exception
{
    public NotActiveException(string message)
        :base(message)
    {            
    }
}

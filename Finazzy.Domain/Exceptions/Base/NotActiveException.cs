using System;

namespace Finazzy.Domain.Exceptions.Base;

public class NotActiveException : Exception
{
    public NotActiveException(string message)
        : base(message)
    {
    }
}

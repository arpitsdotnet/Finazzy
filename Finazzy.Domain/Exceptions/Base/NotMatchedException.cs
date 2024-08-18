using System;

namespace Finazzy.Domain.Exceptions.Base;

public class NotMatchedException : Exception
{
    public NotMatchedException(string message)
        : base(message)
    {
    }
}

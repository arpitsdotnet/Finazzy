using System;

namespace Finazzy.Users.Domain.Exceptions.Base;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}

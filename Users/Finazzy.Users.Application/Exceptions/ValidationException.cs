using System.Collections.Generic;
using Finazzy.Users.Domain.Exceptions.Base;

namespace Finazzy.Users.Application.Exceptions;

public sealed class ValidationException : BadRequestException
{
    public ValidationException(Dictionary<string, string[]> errors)
        : base("Validation errors occurred") =>
        Errors = errors;

    public Dictionary<string, string[]> Errors { get; }
}

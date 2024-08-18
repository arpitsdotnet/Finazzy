using Finazzy.Domain.Entities.Base;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.CreateUser;

public static class CreateUserErrors
{
    public static readonly Error AlreadyExists = new("CreateUser.AlredyExists", "User already exists.");
}
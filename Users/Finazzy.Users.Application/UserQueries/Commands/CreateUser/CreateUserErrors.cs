using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUser;

public static class CreateUserErrors
{
    public static readonly Error AlreadyExists = new("CreateUser.AlredyExists", "User already exists.");
}
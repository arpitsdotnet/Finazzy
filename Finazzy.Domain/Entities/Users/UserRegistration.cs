using Finazzy.Domain.Primitives;
using System;

namespace Finazzy.Domain.Entities.Users;

public sealed class UserRegistration : Entity
{
    private UserRegistration(Guid id, string username, string password)
        : base(id)
    {
        Username = username;
        Password = password;
    }
    private UserRegistration(UserRegistration user, string username)
        : base(user.Id)
    {
        Username = username;
    }

    private UserRegistration() { }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public DateTime RegisteredOn { get; private set; } = DateTime.Now;

    public static UserRegistration Create(string username, string password) =>
        new UserRegistration(Guid.NewGuid(), username, password);

    public static UserRegistration UpdateUsername(UserRegistration user, string username) =>
        new UserRegistration(user, username);

    public static UserRegistration UpdatePassword(Guid id, string username, string password) =>
        new UserRegistration(id, username, password);
}

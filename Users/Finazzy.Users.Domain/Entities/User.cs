using Finazzy.Users.Domain.Primitives;
using System;

namespace Finazzy.Users.Domain.Entities;

public sealed class User : Entity
{
    private User(Guid id, string username, string password)
        : base(id)
    {
        Username = username;
        Password = password;
    }
    private User(User user, string username)
        : base(user.Id)
    {
        Username = username;
    }

    private User() { }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public DateTime RegisteredOn { get; private set; } = DateTime.Now;
    
    public static User Create(string username, string password) =>
        new User(Guid.NewGuid(), username, password);

    public static User UpdateUsername(User user, string username) =>
        new User(user, username);

    public static User UpdatePassword(Guid id, string username, string password) => 
        new User(id, username, password);
}

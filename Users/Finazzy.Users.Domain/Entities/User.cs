using Finazzy.Users.Domain.Primitives;
using System;

namespace Finazzy.Users.Domain.Entities;

public sealed class User : Entity
{
    public User(Guid id, string username, string password)
        : base(id)
    {
        Username = username;
        Password = password;
    }

    private User() { }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public DateTime RegisteredOn { get; private set; } = DateTime.Now;
}

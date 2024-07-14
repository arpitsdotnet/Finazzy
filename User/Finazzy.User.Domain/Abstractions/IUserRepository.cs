using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Domain.Abstractions;

public interface IUserRepository
{
    void Insert(User user);
}

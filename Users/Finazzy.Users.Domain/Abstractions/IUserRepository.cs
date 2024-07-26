using System;
using System.Collections.Generic;
using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Domain.Abstractions;

public interface IUserRepository
{
    List<User> GetAll(int pageNo = 0);
    User GetById(Guid userId);
    User GetByUsername(string username);
    void Insert(User user);
    void Update(User user);
}

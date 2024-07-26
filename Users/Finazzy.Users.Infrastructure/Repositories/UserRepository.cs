using System;
using System.Collections.Generic;
using System.Linq;
using Finazzy.Users.Domain.Abstractions;
using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private const int PageSize = 20;
    
    private readonly UserApplicationDbContext _dbContext;

    public UserRepository(UserApplicationDbContext dbContext) => _dbContext = dbContext;

    public List<User> GetAll(int pageNo = 0) => 
        _dbContext.Set<User>()
        .Take(pageNo * PageSize + 1)
        .Skip((pageNo + 1) * PageSize)
        .ToList();

    public User GetById(Guid userId) => 
        _dbContext.Set<User>()
        .FirstOrDefault(x => x.Id == userId);

    public User GetByUsername(string username) => 
        _dbContext.Set<User>()
        .FirstOrDefault(x => x.Username == username);

    public void Insert(User user) => 
        _dbContext.Set<User>()
        .Add(user);

    public void Update(User user) => 
        _dbContext.Set<User>()
        .Update(user);

}

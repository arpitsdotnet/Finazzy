using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Finazzy.Domain.Abstractions.Users;
using Finazzy.Domain.Entities.Users;
using Finazzy.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Finazzy.Infrastructure.Repositories.Users;

public class UserRegistrationRepository : IUserRegistrationRepository
{
    private const int PageSize = 20;

    private DbSet<UserRegistration> _dbSet;

    private readonly ApplicationDbContext _dbContext;

    public UserRegistrationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<UserRegistration>();
    }

    public List<UserRegistration> GetAll(int pageNo = 0) =>
        _dbSet
        .Take(pageNo * PageSize + 1)
        .Skip((pageNo + 1) * PageSize)
        .ToList();

    public UserRegistration Get(Expression<Func<UserRegistration, bool>> filter) =>
        _dbSet
        .FirstOrDefault(filter);

    public UserRegistration GetById(Guid userId) =>
        _dbSet
        .FirstOrDefault(x => x.Id == userId);

    public UserRegistration GetByUsername(string username) =>
        _dbSet
        .FirstOrDefault(x => x.Username == username);

    public void Insert(UserRegistration user) =>
        _dbSet
        .Add(user);

    public void Update(UserRegistration user) =>
        _dbSet
        .Update(user);

}

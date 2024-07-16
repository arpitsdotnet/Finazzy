using Finazzy.Users.Domain.Abstractions;
using Finazzy.Users.Domain.Entities;

namespace Finazzy.Users.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserApplicationDbContext _dbContext;

    public UserRepository(UserApplicationDbContext dbContext) => _dbContext = dbContext;

    public void Insert(User user) => _dbContext.Set<User>().Add(user);
}

using Finazzy.Users.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Finazzy.Users.Infrastructure;

public sealed class UserApplicationDbContext : DbContext, IUnitOfWork
{
    public UserApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserApplicationDbContext).Assembly);
}

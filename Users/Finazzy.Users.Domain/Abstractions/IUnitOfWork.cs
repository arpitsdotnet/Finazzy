using System;
using System.Threading;
using System.Threading.Tasks;

namespace Finazzy.Users.Domain.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

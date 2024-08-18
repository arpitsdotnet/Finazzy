using System;
using System.Threading;
using System.Threading.Tasks;

namespace Finazzy.Domain.Abstractions.Base;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

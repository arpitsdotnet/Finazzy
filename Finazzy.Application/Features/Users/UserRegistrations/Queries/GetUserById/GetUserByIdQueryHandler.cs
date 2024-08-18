using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Finazzy.Application.Abstractions.Messaging;
using Finazzy.Application.Features.Users.UserRegistrations.Queries.GetUserById;
using Finazzy.Domain.Exceptions.Users;

namespace Finazzy.Users.Application.UserQueries.Queries.GetUserById;

internal class GetUserByIdQueryHandler(IDbConnection dbConnection) : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IDbConnection _dbConnection = dbConnection;

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        const string query = @"SELECT * FROM [user].[Users] WHERE Id = @UserId";

        var user = await _dbConnection.QueryFirstOrDefaultAsync<UserResponse>(
            query,
            new { request.UserId });

        return user ?? throw new UserNotFoundException(request.UserId);
    }
}

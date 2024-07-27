using Finazzy.Users.Application.UserQueries.Commands.CreateUser;
using Finazzy.Users.Application.UserQueries.Queries.GetUserById;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finazzy.Users.Presentation.Controllers;

public sealed class UserController : ApiController
{
    /// <summary>
    /// Gets the user with the specified identifier, if it exists.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{userId:guid}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUser(Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(userId);

        var user = await Sender.Send(query, cancellationToken);

        return Ok(user);
    }

    /// <summary>
    /// Creates a new user based on specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateUserCommand>();

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(CreateUser), new { UserId = result.Data }, result.Data)
            : new ObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Type = "https://tools.ietf.org/html/rcf7231#Section-6.5.1",
                Title = result.Error.Code,
                Detail = result.Error.Description
            });
    }
}

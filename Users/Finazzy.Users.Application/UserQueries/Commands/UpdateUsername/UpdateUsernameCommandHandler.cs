using System.Threading;
using System.Threading.Tasks;
using Finazzy.Users.Application.Abstractions.Messaging;
using Finazzy.Users.Domain.Abstractions;
using Finazzy.Users.Domain.Entities;
using Finazzy.Users.Domain.Exceptions;

namespace Finazzy.Users.Application.UserQueries.Commands.UpdateUsername;

public sealed class UpdateUsernameCommandHandler : ICommandHandler<UpdateUsernameCommand, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsernameCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
    {
        var existingUser = _userRepository.GetById(request.Id);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.Id);
        }

        var user = User.UpdateUsername(existingUser, request.Username);
        
        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }
}

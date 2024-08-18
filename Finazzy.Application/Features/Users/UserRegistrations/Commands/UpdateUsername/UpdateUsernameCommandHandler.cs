using System.Threading;
using System.Threading.Tasks;
using Finazzy.Application.Abstractions.Messaging;
using Finazzy.Domain.Abstractions.Base;
using Finazzy.Domain.Abstractions.Users;
using Finazzy.Domain.Entities.Users;
using Finazzy.Domain.Exceptions.Users;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.UpdateUsername;

public sealed class UpdateUsernameCommandHandler : ICommandHandler<UpdateUsernameCommand, UserRegistration>
{
    private readonly IUserRegistrationRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUsernameCommandHandler(
        IUserRegistrationRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserRegistration> Handle(UpdateUsernameCommand request, CancellationToken cancellationToken)
    {
        var existingUser = _userRepository.GetById(request.Id);

        if (existingUser == null)
        {
            throw new UserNotFoundException(request.Id);
        }

        var user = UserRegistration.UpdateUsername(existingUser, request.Username);

        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }
}

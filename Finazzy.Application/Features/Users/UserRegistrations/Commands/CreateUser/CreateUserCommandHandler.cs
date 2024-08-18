using Finazzy.Application.Abstractions.Messaging;
using Finazzy.Domain.Abstractions.Base;
using Finazzy.Domain.Abstractions.Users;
using Finazzy.Domain.Entities.Base;
using Finazzy.Domain.Entities.Users;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.CreateUser;

public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRegistrationRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IUserRegistrationRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = _userRepository.GetByUsername(request.Username);
        if (existingUser != null)
        {
            return Result<Guid>.Failure(CreateUserErrors.AlreadyExists);
        }

        var user = UserRegistration.Create(request.Username, request.Password);

        _userRepository.Insert(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;

    }
}

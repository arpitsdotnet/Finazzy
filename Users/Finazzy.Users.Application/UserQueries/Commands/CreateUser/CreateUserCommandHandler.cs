using System;
using System.Threading;
using System.Threading.Tasks;
using Finazzy.Users.Application.Abstractions.Messaging;
using Finazzy.Users.Domain.Abstractions;
using Finazzy.Users.Domain.Entities;
using MediatR;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUser;

public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
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

        var user = User.Create(request.Username, request.Password);

        _userRepository.Insert(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;

    }
}

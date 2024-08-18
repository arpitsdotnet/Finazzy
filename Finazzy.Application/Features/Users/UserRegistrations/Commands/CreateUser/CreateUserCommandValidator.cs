using FluentValidation;

namespace Finazzy.Application.Features.Users.UserRegistrations.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .Length(5, 50);
        RuleFor(x => x.Password)
            .NotEmpty()
            .Length(5, 50);
    }
}

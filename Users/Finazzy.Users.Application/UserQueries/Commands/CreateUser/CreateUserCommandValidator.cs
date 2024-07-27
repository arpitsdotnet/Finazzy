using FluentValidation;

namespace Finazzy.Users.Application.UserQueries.Commands.CreateUser;

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

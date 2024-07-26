using FluentValidation;

namespace Finazzy.Users.Application.UserQueries.Commands.UpdateUsername;

public sealed class UpdateUsernameCommandValidator : AbstractValidator<UpdateUsernameCommand>
{
    public UpdateUsernameCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
    }
}

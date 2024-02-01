using communication.Requests.User;
using FluentValidation;

namespace Application.UseCases.User.LoginUser;

public class LoginUserValidation : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidation()
    {
        When(x => x.Credentials.First() != '@', () => RuleFor(x => x.Credentials).EmailAddress());
        When(x => x.Credentials.First() == '@', () => RuleFor(x => x.Credentials).NotNull().MinimumLength(3).MaximumLength(100));
        RuleFor(x => x.Password).NotNull().MinimumLength(3).MaximumLength(100);
    }

}

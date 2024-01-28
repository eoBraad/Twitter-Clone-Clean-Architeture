using FluentValidation;
using Communication.Requests.User;
using System.Text.RegularExpressions;

namespace Application.UseCases.User.CreateUser;

public class CreateUserValidation : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidation()
    {

        RuleFor(x => x.Name).NotNull().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.Email).NotNull().EmailAddress();
        RuleFor(x => x.Password).NotNull().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.LastName).NotNull().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.DateOfBirth).Custom((value, context) =>
        {
            var stantadarDate = "^\\d{4}-((0\\d)|(1[012]))-(([012]\\d)|3[01])$";

            var result = Regex.IsMatch(value, stantadarDate);

            if (!result)
            {
                context.AddFailure("DateOfBirth", "Date format must be yyyy-mm-dd");
            }
        });
        When(x => x.DateOfBirth != null, () =>
        {
            RuleFor(x => x.DateOfBirth).Custom((value, context) =>
            {
                if (value.Contains('-'))
                {
                    var dates = value.Split("-");
                    var today = DateTime.Today;

                    if (today.Year - int.Parse(dates[0]) == 18)
                    {
                        if (today.Month >= int.Parse(dates[1]))
                        {  
                           if (today.Day >= int.Parse(dates[2]) == false)
                           {
                             context.AddFailure("DateOfBirth", "User must be at least 18 years old");
                           } 
                        } else {
                            context.AddFailure("DateOfBirth", "User must be at least 18 years old");
                        }
                    } else if (today.Year - int.Parse(dates[0]) < 18)
                    {
                        context.AddFailure("DateOfBirth", "User must be at least 18 years old");
                    }   
                }
            });
        });

        RuleFor(x => x.Username).MinimumLength(9).MaximumLength(20).Custom((value, context) =>
        {
            if (value.First() != '@')
            {
                context.AddFailure("Username", "Username must start with @");
            }
        });
    }
}

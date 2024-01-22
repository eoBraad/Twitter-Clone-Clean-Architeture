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
            var stantadarDate = "/(^0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-(\\d{4}$)/";

            var result =  Regex.IsMatch(value, stantadarDate);

            if(!result)
            {
                context.AddFailure("DateOfBirth", "Date format must be dd-mm-yyyy");
            }
        });
        RuleFor(x => x.DateOfBirth).Custom((value, context) => 
        {
            var dates = value.Split("-");
            var today = DateTime.Today; 

            if (!(int.Parse(dates[0]) >= today.Day) && !(int.Parse(dates[1]) >= today.Month) && !(today.Year - int.Parse(dates[2]) >= 18))  
            {
                context.AddFailure("DateOfBirth", "User must be at least 18 years old");
            }
        });

        RuleFor(x => x.Username).MinimumLength(9).MaximumLength(20).Custom((value, context) => 
        {
            if(value.First() != '@')
            {   
                context.AddFailure("Username", "Username must start with @");
            }
        });
    }
}

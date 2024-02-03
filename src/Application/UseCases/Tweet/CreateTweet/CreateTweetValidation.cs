using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communication.Requests.Tweet;
using FluentValidation;

namespace Application.UseCases.Tweet.CreateTweet;

public class CreateTweetValidation : AbstractValidator<CreateTweetRequest>
{
    public CreateTweetValidation()
    {
        RuleFor(t => t.TweetContent).NotNull().NotEmpty();
    }
}

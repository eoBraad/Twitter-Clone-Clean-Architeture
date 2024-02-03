using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Communication.Requests.Tweet;

namespace Application.UseCases.Tweet.CreateTweet;

public interface ICreateTweetUseCase
{
    public Task Execute(CreateTweetRequest tweetBody, string userId);
}

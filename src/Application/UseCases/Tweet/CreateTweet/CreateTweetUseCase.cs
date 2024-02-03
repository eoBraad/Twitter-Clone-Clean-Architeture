using Application.Services.Utility;
using AutoMapper;
using Communication.Requests.Tweet;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.UseCases.Tweet.CreateTweet;
public class CreateTweetUseCase : ICreateTweetUseCase
{
    private readonly ITweetRepository _tweetRepository;

    private readonly IMapper _mapper;

    public CreateTweetUseCase(IMapper mapper, ITweetRepository tweetRepository)
    {
        _mapper = mapper;
        _tweetRepository = tweetRepository;
    }

    public async Task Execute(CreateTweetRequest tweetBody, string bearer)
    {
        var validation = new CreateTweetValidation().Validate(tweetBody);

        if (!validation.IsValid)
            throw new ValidateException(validation.Errors.Select(x => x.ErrorMessage).ToList());

        var tweet = _mapper.Map<Domain.Entities.Tweet>(tweetBody);

        var userId = Jwt.GetUserByToken(bearer);

        tweet.OwnerId = Guid.Parse(userId);

        await _tweetRepository.CreateTweetAsync(tweet);
    }
}

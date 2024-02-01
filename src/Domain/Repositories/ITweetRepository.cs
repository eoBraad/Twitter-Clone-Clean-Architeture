using Domain.Entities;

namespace Domain.Repositories;

public interface ITweetRepository
{
    public Task CreateTweetAsync(Tweet tweet);

    public Task<List<Tweet>> GetAllTweetsOrderByDateAsync();

}

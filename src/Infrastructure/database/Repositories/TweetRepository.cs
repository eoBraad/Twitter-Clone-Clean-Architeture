using Domain;
using Infrastructure.database.context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TweetRepository : ITweetRepository
{
    private readonly TwitterCloneContext _context;

    public TweetRepository(TwitterCloneContext context)
    {
        _context = context;
    }
    public async Task CreateTweetAsync(Tweet tweet)
    {
        await _context.Tweets.AddAsync(tweet);

        _context.SaveChanges();
    }

    public async Task<List<Tweet>> GetAllTweetsOrderByDateAsync()
    {
        return await _context.Tweets.OrderByDescending(x => x.CreatedAt).ToListAsync();
    }
}

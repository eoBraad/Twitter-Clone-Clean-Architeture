using Domain.Repositories;
using Infrastructure;
using Infrastructure.database.Repositories;

namespace Api.Config
{
    public static class AddRepositories
    {
        public static void ConfigureRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ITweetRepository, TweetRepository>();
        }

    }
}
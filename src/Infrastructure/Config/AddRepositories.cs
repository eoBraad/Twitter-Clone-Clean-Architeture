using Domain.Repositories;
using Infrastructure.database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Config;

public static class AddRepositories
{
    public static void AddRepositoriesInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}

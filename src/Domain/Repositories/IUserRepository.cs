using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    public Task CreateUserAsync(User user);

    public Task CheckUsernameOrEmailExistAsync(string username, string email);
}

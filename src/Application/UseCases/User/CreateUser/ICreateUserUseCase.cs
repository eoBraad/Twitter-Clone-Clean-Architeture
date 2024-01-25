using Communication.Requests.User;

namespace Application.UseCases.User.CreateUser;

public interface ICreateUserUseCase
{
    public Task<string> Execute(CreateUserRequest request);
}

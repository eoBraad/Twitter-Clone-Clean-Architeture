using Communication.Requests.User;
using Communication.Responses;

namespace Application.UseCases.User.CreateUser;

public interface ICreateUserUseCase
{
    public Task<CreateUserResponse> Execute(CreateUserRequest request);
}

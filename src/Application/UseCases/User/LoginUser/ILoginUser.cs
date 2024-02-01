using communication.Requests.User;
using communication.Responses;

namespace Application.UseCases.User.LoginUser;

public interface ILoginUser
{
    public Task<LoginUserResponse> Execute(LoginUserRequest request);
}

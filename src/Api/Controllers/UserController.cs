using Application.UseCases.User.CreateUser;
using Communication.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, [FromServices] ICreateUserUseCase createUserUseCase)
    {
        var requestResult = await createUserUseCase.Execute(request);

        return Ok(requestResult);
    }
}

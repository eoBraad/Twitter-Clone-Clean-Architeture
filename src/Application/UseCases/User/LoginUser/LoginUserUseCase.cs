using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Services.Utility;
using communication.Requests.User;
using communication.Responses;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.UseCases.User.LoginUser;

public class LoginUserUseCase : ILoginUserUseCase
{
    private readonly IUserRepository _userRepository;

    private readonly Jwt _jwt;

    public async Task<LoginUserResponse> Execute(LoginUserRequest request)
    {
        var validation = new LoginUserValidation().Validate(request);

        if (!validation.IsValid)
        {
            throw new ValidateException(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        var user = await _userRepository.LoginUserAsync(request.Credentials, request.Password) ?? throw new UseCaseException("Invalid User Creadential or Password", (int)HttpStatusCode.Unauthorized);

        var token = _jwt.GenerateToken(user);

        return new LoginUserResponse() { Token = token };
    }
}

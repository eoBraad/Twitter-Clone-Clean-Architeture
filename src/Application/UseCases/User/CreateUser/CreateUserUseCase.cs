using Application.Services.Utility;
using AutoMapper;
using Communication.Requests.User;
using Communication.Responses;
using Domain.Exceptions;
using Domain.Repositories;

namespace Application.UseCases.User.CreateUser;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    private readonly Jwt _jwt;

    public CreateUserUseCase(IUserRepository userRepository, IMapper mapper, Jwt jwt)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _jwt = jwt;
    }
    public async Task<CreateUserResponse> Execute(CreateUserRequest request)
    {
        var validation = new CreateUserValidation().Validate(request);
        
        if (!validation.IsValid)
        {
            throw new ValidateException(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        await _userRepository.CheckUsernameOrEmailExistAsync(request.Username, request.Email);

        request.Password = Encrypt.EncryptPassword(request.Password);

        var user = _mapper.Map<Domain.Entities.User>(request);

        await _userRepository.CreateUserAsync(user);

        var token = _jwt.GenerateToken(user);

        return new CreateUserResponse(token, "User created successfully");
    }
}

using AutoMapper;
using Communication.Requests.Tweet;
using Communication.Requests.User;
using Domain.Entities;

namespace Application.Services.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<CreateTweetRequest, Tweet>();
    }
}

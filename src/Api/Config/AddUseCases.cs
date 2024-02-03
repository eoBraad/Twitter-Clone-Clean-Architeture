using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.Tweet.CreateTweet;
using Application.UseCases.User.CreateUser;
using Application.UseCases.User.LoginUser;

namespace Api.Config;

public static class AddUseCases
{
    public static void ConfigureUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        service.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
        service.AddScoped<ICreateTweetUseCase, CreateTweetUseCase>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.User.CreateUser;

namespace Api.Config;

public static class AddUseCases
{
    public static void ConfigureUseCases(this IServiceCollection service)
    {
        service.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
    }
}
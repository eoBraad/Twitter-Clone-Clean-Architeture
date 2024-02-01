using System.Net;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Infrastructure.database.context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.database.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TwitterCloneContext _context;

    public UserRepository(TwitterCloneContext context)
    {  
        _context = context;   
    }
    public async Task CheckUsernameOrEmailExistAsync(string username, string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username || x.Email == email);

        if (user == null) 
            return;
        
        if (user.Username == username)
            throw new UseCaseException("Username already exists", (int)HttpStatusCode.BadRequest);
        
        if (user.Email == email)
            throw new UseCaseException("Email already exists", (int)HttpStatusCode.BadRequest);
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
    }

    public async Task<User> LoginUserAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => (x.Username == username || x.Email == username) && x.Password == password);

        return user;
    }
}
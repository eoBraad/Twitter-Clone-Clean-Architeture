using Domain.Entities;
using Domain.Repositories;
using Infrastructure.database.context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.database.Repositories;

class UserRepository : IUserRepository
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
            throw new Exception("Username already exists");
        
        if (user.Email == email)
            throw new Exception("Email already exists");
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
    }
}
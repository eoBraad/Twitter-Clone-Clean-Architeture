using Microsoft.EntityFrameworkCore;

namespace Infrastructure.database.context;

public class TwitterCloneContext: DbContext
{
    public TwitterCloneContext(DbContextOptions<TwitterCloneContext> opt) : base(opt)
    {
    }

}

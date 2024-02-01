using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.database.context;

public class TwitterCloneContext : DbContext
{
    public TwitterCloneContext(DbContextOptions<TwitterCloneContext> opt) : base(opt) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Tweet> Tweets { get; set; }

    public DbSet<Likes> Likes { get; set; } = default!; // <==>
}

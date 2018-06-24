using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SLEntities
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> DbUsers { get; set; } 

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using UserService.DataAccess.Configurations;
using UserService.Models;

namespace UserService.DataAccess.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserConfiguration().Configure(builder.Entity<User>());
        }

        // These have to be lower-case. Postgres can't work with case sensitive table names.
        public DbSet<User> users { get; set; }
    }
}

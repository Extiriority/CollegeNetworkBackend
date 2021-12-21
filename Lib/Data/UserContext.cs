using CollegeNetworkBackend1.Lib.Logic.User;
using Microsoft.EntityFrameworkCore;

namespace CollegeNetworkBackend1.Lib.Data
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.email).IsUnique(); });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace aspnetcore_identity_server.IdentityServer.Data
{
    public class User : IdentityUser
    {
    }

    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}

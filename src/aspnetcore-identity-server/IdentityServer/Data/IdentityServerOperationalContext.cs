using Microsoft.EntityFrameworkCore;
using System.Linq;
using TwentyTwenty.IdentityServer4.EntityFrameworkCore.DbContexts;

namespace aspnetcore_identity_server.IdentityServer.Data
{

    public class IdentityServerOperationalContext : OperationalContext
    {
        public IdentityServerOperationalContext(DbContextOptions<IdentityServerOperationalContext> options)
            : base(new DbContextOptions<OperationalContext>(options.Extensions.ToDictionary(e => e.GetType(), e => e)))
        {
        }
    }
}

using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_identity_server.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static void ConfigureIdentityServerServices(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<IdentityServerOperationalContext>(o => o.UseSqlServer(connectionString));

            var identity = services
                .AddIdentityServer(o => o.RequireSsl = false)
                .AddInMemoryClients(Clients)
                .AddInMemoryScopes(Scopes);

            identity.SetSigningCredential(IdentityServerSigning.SecurityKey);

            identity.ConfigureEntityFramework().RegisterOperationalStores<IdentityServerOperationalContext>();

            //identity.Services.AddTransient<IProfileService, ProfileService>();
        }

        public static void ConfigureIdentityServerApp(this IApplicationBuilder app)
        {
            app.UseIdentityServer();
        }

        private static IEnumerable<Client> Clients
        {
            get
            {
                yield break;
            }
        }

        private static IEnumerable<Scope> Scopes
        {
            get
            {
                yield break;
            }
        }
    }
}

using aspnetcore_identity_server.IdentityServer.Data;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace aspnetcore_identity_server.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static void ConfigureIdentityServerServices(this IServiceCollection services, string connectionString)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<UserContext>(o => o.UseSqlServer(connectionString))
                .AddDbContext<IdentityServerOperationalContext>(o => o.UseSqlServer(connectionString))
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            var identity = services
                .AddIdentityServer(o => o.RequireSsl = false)
                .AddInMemoryClients(Clients)
                .AddInMemoryScopes(Scopes);

            identity.SetSigningCredential(IdentityServerSigning.SecurityKey);
        
            identity.ConfigureEntityFramework().RegisterOperationalStores<IdentityServerOperationalContext>();

            services.AddMvc();

            identity.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            identity.Services.AddTransient<IProfileService, ProfileService>();
        }

        public static void ConfigureIdentityServerApp(this IApplicationBuilder app)
        {
            app.UseIdentityServer();
            app.UseMvc();
        }

        private static IEnumerable<Client> Clients
        {
            get
            {
                yield return new Client
                {
                    ClientId = "app-using-this-identity-server",
                    ClientName = "Some app or API client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    //RedirectUris = new List<string>
                    //{
                    //    "http://localhost:3308/signin-oidc"
                    //},

                    //PostLogoutRedirectUris = new List<string>
                    //{
                    //    "http://localhost:3308/"
                    //},

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = Scopes.Select(s => s.Name).ToList()
                };
            }
        }

        private static IEnumerable<Scope> Scopes
        {
            get
            {
                yield return StandardScopes.OpenId;
                yield return StandardScopes.Profile;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace aspnetcore_some_api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseJwtBearerAuthentication(new JwtBearerOptions()
            {
                Audience = "http://localhost:54710/resources",
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "http://localhost:54710",
                    ValidAudience = "http://localhost:54710/resources",
                    IssuerSigningKey = new RsaSecurityKey(Newtonsoft.Json.JsonConvert.DeserializeObject<RSAParameters>("{\"D\":null,\"DP\":null,\"DQ\":null,\"Exponent\":\"AQAB\",\"InverseQ\":null,\"Modulus\":\"439rhEc+WB6j/ds2m3Kqfm9+aYQsM7fzOjDUWn5r/7b3lyOOy0MX+24h+kwXCQqne2MAwByxt2yXQwEk5/HR8o2PCTbgeb9OhvC1Biq2E5UAzpBK9F06H/q+zwkeVJyHFUn4d96HfevzzC/rrZgTiFhuD3TYxtd0c5JNR3gbmd+PvAwzzzdrgSwnGmyHVJk6GHmw5ilaeupBn3w8ITleQy8jh//jO0RxQaXnEY6LlMYFC7lZx1gNrEgxw0gIW8UuWebV6p1SU9A4nP79PTQcDITXWEyiDWJtIhNRJqLviCB4EnwJQ/IgewEBU/yNYrOaQqPrLiMmNS5VfqfrczYOqQ==\",\"P\":null,\"Q\":null}"))
                }
            });

            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace aspnetcore_some_api.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        // GET api/values
        [HttpGet]
        [Authorize]
        public string Get()
        {
            return "Hello " + User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
        }
    }
}

using aspnetcore_identity_server.IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace aspnetcore_identity_server.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        /// <summary>
        /// Registers a new user 
        /// </summary>
        /// <param name="model">The email adress and password for the new user</param>
        /// <returns></returns>
        public async Task<IActionResult> Post(RegisterAccountData model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.email, Email = model.email };
                var result = await _userManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    return Ok();
                }

                return StatusCode((int)HttpStatusCode.InternalServerError, string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, "You must pass an email and pasword field.");
        }
    }

    public class RegisterAccountData
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}

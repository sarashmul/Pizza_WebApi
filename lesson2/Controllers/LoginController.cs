using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MyModelsLib;
using MyModelsLib.Interface;
using MyFileServiceLib;
using MyFileServiceLib.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lesson2.login;
using System.Security.Cryptography;

namespace lesson2.Controllers
{
    [Route("[controller]")]
    public class LoginController : BaseCcntroller
    {
        private readonly ILogger<LoginController> _logger;
        public ILoginService _user;

        public LoginController(ILogger<LoginController> logger, ILoginService user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> Login(string name, string password)
        {

            if (password.Equals("329"))
            {
                return Unauthorized();
            }


            var claims = new List<Claim>
     {
         new Claim("role", "Admin"),
         new Claim("name","john"),
         new Claim("brithdatae","")
     };

            var token = MyPizzaTokenService.GetToken(claims);

            return new OkObjectResult(MyPizzaTokenService.WriteToken(token));
        }

        //         [HttpPost]
        //         [Route("[action]")]
        //         [Authorize(Policy = "Admin")]
        // #pragma warning disable IDE0060 // Remove unused parameter
        //         public IActionResult GenerateBadge( Worker worker)
        // #pragma warning restore IDE0060 // Remove unused parameter
        //         {

        //             var claims = new List<Claim>
        //       {
        //           new Claim("role", "Admin")
        //       };

        //             var token = MyPizzaTokenService.GetToken(claims);


        //             return new OkObjectResult(MyPizzaTokenService.WriteToken(token));
        //         }
    }
}
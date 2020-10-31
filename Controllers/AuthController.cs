using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using news.DbModels;
using news.Models.AuthModel;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using System.Security.Claims;

namespace news.Controllers
{
    public class AuthController : Controller
    {
        private readonly pmaDatabaseContext _dbContext;
        
        public AuthController(pmaDatabaseContext dbC)
        {
            _dbContext = dbC;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginData ld)
        {
            var result = _dbContext.Users.Where(x => (x.Username.Equals(ld.Username) && x.Password.Equals(ld.Password))).FirstOrDefault();

            if (result == null)
            {
                
                return RedirectToRoute(new
                {
                    controller = "auth",
                    action = "login"
                });
            }
            else
            {
                var a =new  Claim(ClaimTypes.NameIdentifier, result.UserId.ToString());
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, ld.Username),
                    new Claim(ClaimTypes.Role, result.TypeId.ToString()
                    )
                };
                claims.Add(a);

                var identity = new ClaimsIdentity(claims, "myidentity");

                var userPrincipal = new ClaimsPrincipal(
                    new[] { identity });


                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToRoute(new
                {
                    controller = "home",
                    action = "index"
                });
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToRoute(new
            {
                controller = "auth",
                action = "login"
            });
        }

        
    }
}

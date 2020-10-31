using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace news.Controllers
{
    public class PostsController : Controller
    {
        [Authorize(Roles = "2,3")] //pristup publisher i admin
        public IActionResult MyPosts()
        {
            return View();
        }

        

        
    }
}
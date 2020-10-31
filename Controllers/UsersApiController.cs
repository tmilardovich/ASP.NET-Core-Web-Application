using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using news.DtoMappers;
using news.Models;
using Newtonsoft.Json.Linq;
using news.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace news.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private UserService _userservice;

        
        public UsersApiController(UserService userservice)
        {
            _userservice = userservice;
            
        }
        
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _userservice.GetAll().ToList();
        }

        [HttpPost("saveuser2")]
        public ActionResult Save([FromBody] JObject json)
        {
            var user = UserDto.FromJson(json);
            var username = user.Username; //poslat u metodu koja provjerava ima li taj username
            var result = _userservice.Check(username);
            if(result == false)
            {
                //user ne postoji
                _userservice.Save(user);
                return Ok();
            }
            else
            {
                ModelState.AddModelError("usernameError", "Username already exists.");
                return BadRequest(ModelState);
            }
            
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "3")]
        public void DeleteUser(string id)
        {
            _userservice.Delete(id);
        }
    }
}

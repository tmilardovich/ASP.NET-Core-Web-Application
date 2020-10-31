using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using news.DtoMappers;
using news.Models;
using news.Services;
using Newtonsoft.Json.Linq;

namespace news.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsApiController : ControllerBase
    {
        private PostService _postService;

        public PostsApiController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Authorize] 
        public ActionResult<List<Post>> Get()
        {
            return _postService.GetAll().ToList();


        }

        [HttpPost("savepost")]
        public ActionResult Save([FromBody] JObject json)
        {
            var post = PostDto.PostFromJson(json);
            _postService.SavePost(post);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize] 
        public ActionResult<List<Post>> GetPosts(string id)
        {
            return _postService.GetPostFromOneUser(id).ToList();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void DeletePost(string id)
        {
            int id2 = int.Parse(id);
            _postService.DeletePost(id2);
        }

        [HttpPut("editpost")]
        [Authorize]
        public void EditPost([FromBody] JObject json)
        {
            var post = PostDto.PostFromJson(json);
            _postService.EditPost(post);
            
        }
    }
}
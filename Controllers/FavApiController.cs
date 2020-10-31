using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using news.Models;
using news.Services;

namespace news.Controllers
{
    [Route("api/favourites")]
    [ApiController]
    public class FavApiController : ControllerBase
    {
        private FavService _fService;

        public FavApiController(FavService favService)
        {
            _fService = favService;
        }


        [HttpGet("{id}")] //user id se salje
        public ActionResult<List<Fav>> Get(int id)
        {
            return _fService.GetFavourites(id).ToList();


        }

        [HttpPost("{idUser}/{postLiked}")]
        public void SaveToFavourites(int idUser, int postLiked)
        {
            _fService.Save(idUser, postLiked);
        }


        [HttpDelete("{n}")]
        public void DeleteFromSaved(int n)
        {
            _fService.DeleteSaved(n);
        }
    }
}

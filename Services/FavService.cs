using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using news.Models;
using news.Repositories;

namespace news.Services
{
    public class FavService
    {
        private FavRepository _favRepository;

        public FavService(FavRepository fRepo)
        {
            _favRepository = fRepo;
        }

        public IEnumerable<Fav> GetFavourites(int id)
        {
            return _favRepository.GetFavourites(id);
        }

        public void Save(int userID, int postID)
        {
            _favRepository.Save(userID, postID);
        }

        public void DeleteSaved(int n)
        {
            _favRepository.Delete(n);
        }




    }
}

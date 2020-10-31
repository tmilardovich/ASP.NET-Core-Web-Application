using Microsoft.EntityFrameworkCore;
using news.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using news.Mappers;
using Microsoft.Extensions.Configuration.UserSecrets;
using news.Models;

namespace news.Repositories
{
    public class FavRepository
    {
        private readonly pmaDatabaseContext _dbContext;


        public FavRepository(pmaDatabaseContext dbCon)
        {
            _dbContext = dbCon;
        }

        public IEnumerable<Models.Fav> GetFavourites(int id)
        {
            return _dbContext.UsersPosts.Include(p => p.User).Include(a => a.Post).Where(b => b.UserId == id).Select(x => FavMapper.FromDatabase(x));
        }

        public void Save(int userID, int postID)
        {
            var dbF = new Fav(0,userID.ToString(),postID.ToString());

            var dbFav = FavMapper.PostToDatabase(dbF);
            _dbContext.UsersPosts.Add(dbFav);
            _dbContext.SaveChanges();
        }


        public void Delete(int n)
        {
            var rez = _dbContext.UsersPosts.Where(p => p.UpId == n).SingleOrDefault();
            _dbContext.UsersPosts.Remove(rez);
            _dbContext.SaveChanges();
        }
        



    }
}

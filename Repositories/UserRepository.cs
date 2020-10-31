using Microsoft.EntityFrameworkCore;
using news.DbModels;
using news.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace news.Repositories
{
    public class UserRepository
    {
        private readonly pmaDatabaseContext _dbContext;


        public UserRepository(pmaDatabaseContext dbCon)
        {
            _dbContext = dbCon;
        }

        public IEnumerable<Models.User> GetAll()
        {
            return _dbContext.Users.Include(c=> c.Type).Select(x => UserMapper.FromDatabase(x));
        }

        public void Save(Models.User user)
        {
            var dbUser = UserMapper.ToDatabase(user);
            _dbContext.Users.Add(dbUser);
            _dbContext.SaveChanges();
        }

        public bool CheckIfUserExists(string username)
        {
            var user = _dbContext.Users.Where(x => x.Username == username).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteUser(string name)
        {
            //dobit id usera
            DbModels.Users he = new DbModels.Users();
            
            he = _dbContext.Users.Where(x => x.Username == name).SingleOrDefault();
            var userID = he.UserId;

            //izbrisat iz postova sve
            foreach (var entity in _dbContext.Posts)
            {
                if (entity.UserId == userID)
                {
                    _dbContext.Posts.Remove(entity);
                }
            }

            //izbrisat usera
            _dbContext.Users.Remove(he);
            _dbContext.SaveChanges();

        }
    }
}

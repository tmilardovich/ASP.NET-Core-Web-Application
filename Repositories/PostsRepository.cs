using Microsoft.EntityFrameworkCore;
using news.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using news.Mappers;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace news.Repositories
{
    public class PostsRepository
    {
        private readonly pmaDatabaseContext _dbContext;


        public PostsRepository(pmaDatabaseContext dbCon)
        {
            _dbContext = dbCon;
        }

        public IEnumerable<Models.Post> GetAll()
        {
            return _dbContext.Posts.Include(c => c.User).Select(x => PostMapper.FromDatabase(x));
        }

        public void SavePost(Models.Post post)
        {
            var dbPost = PostMapper.PostToDatabase(post);
            _dbContext.Posts.Add(dbPost);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Models.Post> GetOneUserPosts(string user)
        {
            DbModels.Users he = new DbModels.Users();
            //nac id usera
            he = _dbContext.Users.Where(x => x.Username == user).SingleOrDefault();
            var userID = he.UserId;

            return _dbContext.Posts.Where(post => post.UserId == userID).Select(p => PostMapper.FromDatabase(p));
            
            //nac njegove postove
        }

        public void DeletePost(int post_id)
        {
            var rez = _dbContext.Posts.Where(p => p.PostId == post_id).SingleOrDefault();
            _dbContext.Posts.Remove(rez);
            _dbContext.UsersPosts.RemoveRange(_dbContext.UsersPosts.Where(x => x.PostId == post_id));
            _dbContext.SaveChanges();
        }

        public void EditPost(Models.Post post)
        {
            var dbPost = PostMapper.PostToDatabase(post);
            _dbContext.Posts.Update(dbPost);
            _dbContext.SaveChanges();
        }
    }
}

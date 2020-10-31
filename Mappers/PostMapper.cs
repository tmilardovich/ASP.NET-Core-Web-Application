using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using news.Models;
using news.DbModels;

namespace news.Mappers
{
    public class PostMapper
    {
        public static Post FromDatabase(DbModels.Posts post)
        {
            return new Post(post.PostId,post.Post,post.Time,post.User.UserId);
        }

        public static DbModels.Posts PostToDatabase(Models.Post post)
        {
            var dbPost = new DbModels.Posts();
            dbPost.Post = post.postContent;
            dbPost.PostId = post.postId.HasValue ? post.postId.Value : 0;
            dbPost.Time = post.postTime;
            dbPost.UserId = post.userId_foreignKey;
            return dbPost;
        }
    }
}

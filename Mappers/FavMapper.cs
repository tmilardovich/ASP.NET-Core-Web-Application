using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using news.Models;
using news.DbModels;

namespace news.Mappers
{
    public class FavMapper
    {
        public static Fav FromDatabase(DbModels.UsersPosts f)
        {
            return new Fav(f.UpId, f.User.Username, f.Post.Post);
        }

        public static DbModels.UsersPosts PostToDatabase(Models.Fav f)
        {
            var dbf = new DbModels.UsersPosts();
            dbf.UpId = (int)f._id_primary;
            dbf.UserId = int.Parse(f._userId_foreignKey);
            dbf.PostId = int.Parse(f._postId_foreignKey);

            return dbf;


        }


    }
}

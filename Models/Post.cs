using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news.Models
{
    public class Post
    {
        public int? postId { get; set; }
        public string postContent { get; set; }
        public DateTime postTime { get; set; }
        public int userId_foreignKey { get; set; }

        public Post(int? post_Id, string post_Content, DateTime post_Time, int user_Id_fk)
        {
            postId = post_Id;
            postContent = post_Content;
            postTime = post_Time;
            userId_foreignKey = user_Id_fk;
        }
    }
}

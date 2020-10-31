using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using news.Models;

namespace news.DtoMappers
{
    public static class PostDto
    {
        public static Post PostFromJson(JObject json)
        {
            var pid = json["postId"].ToObject<int?>();
            var content = json["postContent"].ToObject<string>();
            var time = json["postTime"].ToObject<DateTime>();
            var uid = json["userId_foreignKey"].ToObject<int>();
            

            return new Post(pid,content,time,uid);
        }
    }
}

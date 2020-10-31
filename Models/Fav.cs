using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news.Models
{
    public class Fav
    {
        public int? _id_primary { get; set; }
        public string _userId_foreignKey { get; set; }
        public string _postId_foreignKey { get; set; }

        public Fav(int? id_primary, string userId_foreignKey, string postId_foreignKey)
        {
            _id_primary = id_primary;
            _userId_foreignKey = userId_foreignKey;
            _postId_foreignKey = postId_foreignKey;
        }
    }
}

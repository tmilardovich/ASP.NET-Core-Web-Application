using System;
using System.Collections.Generic;

namespace news.DbModels
{
    public partial class Posts
    {
        public Posts()
        {
            UsersPosts = new HashSet<UsersPosts>();
        }

        public int PostId { get; set; }
        public string Post { get; set; }
        public DateTime Time { get; set; }
        public int? UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<UsersPosts> UsersPosts { get; set; }
    }
}
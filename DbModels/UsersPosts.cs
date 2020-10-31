using System;
using System.Collections.Generic;

namespace news.DbModels
{
    public partial class UsersPosts
    {
        public int UpId { get; set; }
        public int? UserId { get; set; }
        public int? PostId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users User { get; set; }
    }
}

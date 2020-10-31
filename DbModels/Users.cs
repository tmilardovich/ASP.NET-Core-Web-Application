using System;
using System.Collections.Generic;

namespace news.DbModels
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
            UsersPosts = new HashSet<UsersPosts>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<UsersPosts> UsersPosts { get; set; }
    }
}

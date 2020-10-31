using System;
using System.Collections.Generic;

namespace news.DbModels
{
    public partial class Type
    {
        public Type()
        {
            Users = new HashSet<Users>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}

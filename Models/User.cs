using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TypeName { get; set; }
        public int? UserId { get; set; }

        public User(string name,
            string surname,
            string email,
            string username,
            string password,
            string typeName,
            int? userid)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Username = username;
            Password = password;
            TypeName = typeName;
            UserId = userid;
        }
    }
}

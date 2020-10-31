using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using news.Models;

namespace news.DtoMappers
{
    public static class UserDto
    {
        public static User FromJson(JObject json)
        {
            var name = json["name"].ToObject<string>();
            var surname = json["surname"].ToObject<string>();
            var email = json["email"].ToObject<string>();
            var username = json["username"].ToObject<string>();
            var pass = json["password"].ToObject<string>();
            var typeName = json["typeName"].ToObject<string>();
            var userid = json["userId"].ToObject<int?>();

            return new User(name,surname,email,username,pass,typeName,userid);
        }
    }
}
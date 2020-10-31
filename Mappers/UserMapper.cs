using news.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news.Mappers
{
    public class UserMapper
    {
        public static User FromDatabase(DbModels.Users user)
        {
            return new User(user.Name, user.Surname,
                user.Email, user.Username, user.Password, 
                user.Type.Name, user.UserId);
        }

        public static DbModels.Users ToDatabase(Models.User user)
        {
            var dbUser = new DbModels.Users();
            dbUser.Name = user.Name;
            dbUser.Surname = user.Surname;
            dbUser.Email = user.Email;
            dbUser.Username = user.Username;
            dbUser.Password = user.Password;
            if(user.TypeName == "reader")
            {
                
                dbUser.TypeId = 1;
            }
            else
            {
                dbUser.TypeId = 2;
            }
            dbUser.UserId = user.UserId.HasValue ? user.UserId.Value : 0;
            return dbUser;

            
        }
    }
}

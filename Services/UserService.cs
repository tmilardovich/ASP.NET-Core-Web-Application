using news.Models;
using news.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Save(User user)
        {
            _userRepository.Save(user);
        }

        public void Delete(string name)
        {
            _userRepository.DeleteUser(name);
        }
        public bool Check(string username)
        {
            return _userRepository.CheckIfUserExists(username);
        }
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using news.Models;
using news.Repositories;

namespace news.Services
{
    public class PostService
    {
        private PostsRepository _postRepository;

        public PostService(PostsRepository postRepo)
        {
            _postRepository = postRepo;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public void SavePost(Post post)
        {
            _postRepository.SavePost(post);
        }

        public IEnumerable<Post> GetPostFromOneUser(string user)
        {
            return _postRepository.GetOneUserPosts(user);
        }
        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }

        public void EditPost(Models.Post p)
        {
            _postRepository.EditPost(p);
        }
        
    }
}

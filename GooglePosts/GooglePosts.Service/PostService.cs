using GooglePost.Core.Entities;
using GooglePost.Core.Repositories;
using GooglePost.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePosts.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository
            ;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public List<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetPostById(int id)
        {
            return _postRepository.GetPostById(id);
        }
    }
}

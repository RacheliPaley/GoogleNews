using GooglePost.Core.Entities;
using GooglePost.Core.Repositories;
using GooglePost.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GooglePosts.Service
{
    public class PostService : IPostService<Post>
    {
        private readonly IPostRepository<Post> _postRepository;

        public PostService(IPostRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _postRepository.GetAll();
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _postRepository.GetPostById(id);
        }
    }
}

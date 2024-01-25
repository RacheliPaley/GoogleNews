using GooglePost.Core.Entities;
using GooglePost.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GooglePosts.Data.Repositories
{
    public class PostRepository : IPostRepository<Post>
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            return await Task.FromResult(_context.Posts.ToList());
        }

        public async Task<Post> GetPostById(int id)
        {
            return await Task.FromResult(_context.Posts.FirstOrDefault(e => e.Id == id));
        }
    }
}

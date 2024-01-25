using GooglePost.Core.Entities;
using GooglePost.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePosts.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;
        }

       

        public List<Post> GetAll()
        {
            return _context.Posts;
        }

        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(e => e.Id == id);
        }
    }
}

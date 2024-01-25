using GooglePost.Core.Entities;
using GooglePost.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GooglePosts.API.Controllers
{
    [Route("")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService<Post> _postService;

        public PostController(IPostService<Post> postsService)
        {
            _postService = postsService;
        }
       
        [HttpGet("/posts")]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _postService.GetAll();
        }

        [HttpGet("/titles")]
        public  async Task<Dictionary<int, string>> GetTitles()
        {
            var titlesDictionary = new Dictionary<int, string>();

            var posts = await _postService.GetAll();

            foreach (var post in posts)
            {
                titlesDictionary.Add(post.Id, post.Title);
            }

            return titlesDictionary;
        }

     

        [HttpGet("/post/{id}")]
        public async Task<Post> Get(int id)
        {
            return await _postService.GetPostById(id);    
        }


    }
}

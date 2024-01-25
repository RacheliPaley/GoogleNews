using GooglePost.Core.Entities;
using GooglePost.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GooglePosts.API.Controllers
{
    [Route("")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postsService)
        {
            _postService = postsService;
        }
       
        [HttpGet("/posts")]
        public IEnumerable<Post> Get()
        {
            return _postService.GetAll();
        }

        [HttpGet("/titles")]
        public Dictionary<int, string> GetTitles()
        {
            var titlesDictionary = new Dictionary<int, string>();

            var posts = _postService.GetAll();

            foreach (var post in posts)
            {
                titlesDictionary.Add(post.Id, post.Title);
            }

            return titlesDictionary;
        }

     

        [HttpGet("/post/{id}")]
        public Post Get(int id)
        {
            return _postService.GetPostById(id);    
        }


    }
}

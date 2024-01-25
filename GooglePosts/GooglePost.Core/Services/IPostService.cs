using GooglePost.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePost.Core.Services
{
    public interface IPostService
    {
        List<Post> GetAll();

        Post GetPostById(int id);
    }
}

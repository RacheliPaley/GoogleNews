using GooglePost.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePost.Core.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetPostById(int id);   
    }
}

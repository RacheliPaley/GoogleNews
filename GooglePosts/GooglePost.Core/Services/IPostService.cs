using GooglePost.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePost.Core.Services
{
    public interface IPostService<T>
    {
        Task<List<T>>  GetAll();

       Task<T> GetPostById(int id);
    }
}

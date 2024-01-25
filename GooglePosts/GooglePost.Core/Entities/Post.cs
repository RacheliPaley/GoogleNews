using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePost.Core.Entities
{
    public class Post
    {
        private static int nextId = 1;  

        public Post()
        {
            Id = nextId++;
        }

        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Source { get; set; }
    }
}

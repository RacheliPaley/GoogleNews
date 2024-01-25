using GooglePost.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Xml.Linq;

namespace GooglePosts.Data
{
    public class DataContext
    {
        // Collection to store posts
        public List<Post> Posts { get; set; }

        public DataContext()
        {
            // Check if posts are already cached in memory
            if (MemoryCache.Default["Posts"] == null)
            {
                // If not, load data from XML and cache it
                LoadAndCacheData();
            }

            // Retrieve posts from cache
            Posts = (List<Post>)MemoryCache.Default["Posts"];
        }

        private void LoadAndCacheData()
        {
            // Load XML document from file
            XDocument xmlDoc = XDocument.Load("rss.xml");

            // Parse XML and create a list of Post objects
            List<Post> posts = xmlDoc.Descendants("item").Select(item =>
                  new Post
                  {
                      // Extract data from XML elements
                      Title = item.Element("title")?.Value,
                      Description = item.Element("description")?.Value,
                      Link = item.Element("link")?.Value,
                      Source = item.Element("source")?.Value
                  }).ToList();

            // Cache the posts with an expiration policy
            MemoryCache.Default.Add("Posts", posts, new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddHours(1) });
        }
    }
}

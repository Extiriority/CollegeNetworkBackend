using System.Collections.Generic;
using System.Linq;
using CollegeNetworkBackend1.Lib.Logic.Post;

namespace CollegeNetworkBackend1.Lib.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly UserContext _context;

        public PostRepository(UserContext context) {
            _context = context;
        }
        
        public Post create(Post post)
        {
            _context.posts.Add(post);
            post.post_id = _context.SaveChanges();
            return post;
        }

        public Post delete(Post post)
        {
            _context.posts.Remove(post);
            _context.SaveChanges();
            return post;
        }

        public IEnumerable<Post> getAll() => _context.posts.AsQueryable();
    }
}
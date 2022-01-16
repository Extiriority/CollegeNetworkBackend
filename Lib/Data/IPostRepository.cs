using System.Collections.Generic;
using CollegeNetworkBackend1.Lib.Logic.Post;

namespace CollegeNetworkBackend1.Lib.Data
{
    public interface IPostRepository
    {
        Post create(Post post);
        IEnumerable<Post> getAll();
    }
}
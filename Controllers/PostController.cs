using CollegeNetworkBackend1.Lib.Data;
using CollegeNetworkBackend1.Lib.Data.Data_Transfer_Objects;
using CollegeNetworkBackend1.Lib.Logic.Post;
using Microsoft.AspNetCore.Mvc;

namespace CollegeNetworkBackend1.Controllers
{
    [Route("api")]
    [ApiController]
    public class PostController : Controller {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository) {
            _repository = repository;
        }
        
        [HttpPost("postMsg")]
        public IActionResult creatPost(PostDto dto) {
            var post = new Post {
                user_id = dto.userId,
                content = dto.content
            };
            _repository.create(post);
            return Ok("Updated successfully");
        }

        [HttpGet("get_all_posts")]
        public IActionResult getAllPosts() {
            var posts = _repository.getAll();
            return Ok(posts);
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeNetworkBackend1.Lib.Logic.Post
{
    public class Post
    {
        [Key]
        public int post_id { get; set; }
        [ForeignKey("id")]
        public int user_id { get; set; }
        public string content { get; set; }
    }
}
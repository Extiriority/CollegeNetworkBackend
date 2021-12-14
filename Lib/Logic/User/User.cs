using System;
using System.Text.Json.Serialization;

namespace CollegeNetworkBackend1.Lib.Logic.User
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        [JsonIgnore] public string password { get; set; }
        public bool isAdmin { get; set; }
    }
}

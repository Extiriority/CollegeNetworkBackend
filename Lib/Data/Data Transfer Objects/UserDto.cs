using System;
using Newtonsoft.Json;

namespace CollegeNetworkBackend1.Lib.Data.Data_Transfer_Objects
{
    public class UserDto
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        [JsonIgnore] public string password { get; set; }
    }
}
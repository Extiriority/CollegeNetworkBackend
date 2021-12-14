using System.Linq;
using CollegeNetworkBackend1.Lib.Logic.User;

namespace CollegeNetworkBackend1.Lib.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public User create(User user) {
            context.users.Add(user);
            user.id = context.SaveChanges();
            return user;
        }
        
        public User getByEmail(string email) => context.users.FirstOrDefault(u => u.email == email);
        
        public User getById(int id) => context.users.FirstOrDefault(u => u.id == id);
        
    }
}
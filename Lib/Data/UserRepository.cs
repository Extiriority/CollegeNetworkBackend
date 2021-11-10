using System.Linq;
using CollegeNetworkBackend1.Lib.Logic.User;

namespace CollegeNetworkBackend1.Lib.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public User create(User user) {
            _context.users.Add(user);
            user.id = _context.SaveChanges();
            return user;
        }

        public User getByEmail(string email) {
            return _context.users.FirstOrDefault(u => u.email == email);
        }

        public User getById(int id) {
            return _context.users.FirstOrDefault(u => u.id == id);
        }
    }
}
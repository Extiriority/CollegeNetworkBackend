using System.Collections.Generic;
using System.Linq;
using CollegeNetworkBackend1.Lib.Logic.User;
using Microsoft.EntityFrameworkCore;

namespace CollegeNetworkBackend1.Lib.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context) {
            _context = context;
        }

        public User create(User user) {
            _context.users.Add(user);
            user.id = _context.SaveChanges();
            return user;
        }

        public User update(User user) {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }
        
        public User delete(User user) {
            _context.users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public IEnumerable<User> getAll() => _context.users.AsQueryable();


        public User getByEmail(string email) => _context.users.FirstOrDefault(u => u.email == email);
        public User getById(int id) => _context.users.FirstOrDefault(u => u.id == id);
        public User findById(int id) => _context.users.Find(id);
        
    }
}
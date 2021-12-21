using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CollegeNetworkBackend1.Lib.Logic.User;

namespace CollegeNetworkBackend1.Lib.Data
{
    public interface IUserRepository
    {
        User create(User user);
        User update(User user);
        User delete(User user);
        IEnumerable<User> getAll();
        User getByEmail(string email);
        User getById(int id);
        User findById(int id);
    }
}
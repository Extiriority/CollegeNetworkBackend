using CollegeNetworkBackend1.Lib.Logic.User;

namespace CollegeNetworkBackend1.Lib.Data
{
    public interface IUserRepository
    {
        User create(User user);
        User getByEmail(string email);
        User getById(int id);
    }
}
using FinTech.Models;

namespace FinTech.Repository
{
    public interface IUserRepository
    {

        IEnumerable<User> getAll();
        User? getUser(int id);
        User add(User user);
        User update(User user);
        void delete(int id);
        User? getByUserName(string userName);

    }
}

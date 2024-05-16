using FinTech.Models;

namespace FinTech.Repository
{
    public class UserRepository : IUserRepository
    {

        private List<User> users = new List<User>();
        private int nextId = 1;
        public UserRepository()
        {

        }
        public IEnumerable<User> getAll()
        {
            return users;
        }

        //Can return null
        public User? getUser(int id)
        {
            return users.Find(u => u.id == id);
        }


        //Can return null
        public User? getByUserName(string userName)
        {
  
            return users.Find(u => u.userName == userName);

        }



        public bool update(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            int index = users.FindIndex(u => u.id == user.id);
            if(index == -1)
            {
                return false;
            }
            users.RemoveAt(index);
            users.Add(user);
            return true;

        }

        public User add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.id = nextId++;
            users.Add(user);
            return user;
        }

        public void delete(int id)
        {
            users.RemoveAll(u => u.id == id);
        }

        User IUserRepository.update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User? GetUserById(int id);

        public User? GetUserByCredentials(UserCredential userCredential);

       public bool DeleteUser(int id);
    }
}

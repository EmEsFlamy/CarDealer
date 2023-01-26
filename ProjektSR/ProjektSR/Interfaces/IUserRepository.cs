using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User? UserGetUserById(int id);

        public User? GetUserByCredentials(UserCredential userCredential);

       
    }
}

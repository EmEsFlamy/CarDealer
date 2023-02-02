using Microsoft.EntityFrameworkCore;
using ProjektSR.Database;
using ProjektSR.Helpers;
using ProjektSR.Interfaces;
using ProjektSR.Models;
using ProjektSR.Models.Enums;
using System.Reflection.Metadata.Ecma335;

namespace ProjektSR.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly EncodeHelper _encodeHelper;
        public UserRepository(ApplicationDbContext context)
        {
            _encodeHelper = EncodeHelper.Instance();
            _context = context;
        }
        public bool CreateUser(User user)
        {
            try
            {
                var usermail = _context.Users.FirstOrDefault(x => x.Email == user.Email);
                if (usermail is not null) return false;
                user.Password = _encodeHelper.Encode(user.Password);
                user.UserType = (int)UserTypeEnum.User;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user is null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User? GetUserByCredentials(UserCredential userCredential)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == userCredential.Email);
            if (user is null) return null;
            var credentialPasswordHash = _encodeHelper.Encode(userCredential.Password);
            if (_encodeHelper.Verify(user.Password, credentialPasswordHash)) return null;
            return user;
        }

        public User? GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

    }
}

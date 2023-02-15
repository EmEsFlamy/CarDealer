using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface ITokenRepository
    {
        public string CreateToken(User user);
    }
}

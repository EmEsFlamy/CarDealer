using Microsoft.AspNetCore.Identity;
using System.Text;

namespace ProjektSR.Helpers
{
    public class EncodeHelper
    {
        private static EncodeHelper? _encodeHelper;
        private EncodeHelper()
        {
            
        }
        public static EncodeHelper Instance()
        {
            if (_encodeHelper is null) _encodeHelper = new EncodeHelper();
            return _encodeHelper;
        }
        public string Encode(string text)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(text,BCrypt.Net.HashType.SHA512);
            return passwordHash;
        }
        public bool Verify(string pwd1, string pwd2) 
        {
            bool verified = BCrypt.Net.BCrypt.EnhancedVerify(pwd1, pwd2, BCrypt.Net.HashType.SHA512);
            return verified;
        }
            

    }
}

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
            var bytes  = Encoding.UTF8.GetBytes(text);
            var hash = Convert.ToBase64String(bytes);
            return hash;
        }
        public bool Verify(string pwd1, string pwd2) 
        {
            return pwd1 == pwd2;
        }
            

    }
}

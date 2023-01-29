using System.Text.Json.Serialization;

namespace ProjektSR.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }

        [JsonIgnore]
        public Payment? Payments { get; set; }

        [JsonIgnore]
        public Order? Orders { get; set; }
    }
}

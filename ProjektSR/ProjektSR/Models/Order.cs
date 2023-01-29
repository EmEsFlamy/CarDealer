using System.Text.Json.Serialization;

namespace ProjektSR.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int CarId { get; set; }
        [JsonIgnore]
        public Car? Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public Payment? Payment { get; set; }
    }
}

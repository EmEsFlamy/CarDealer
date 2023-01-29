using System.Text.Json.Serialization;

namespace ProjektSR.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int CarType { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public Order? Orders { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ProjektSR.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public virtual int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public bool IsPaid { get; set; } = false;
        public int? TotalPrice { get; set; }
    }
}

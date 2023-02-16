namespace ProjektSR.Models
{
    public class PaymentCredentials
    {
        public int PaymentId { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}

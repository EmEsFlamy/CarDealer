namespace ProjektSR.Models
{
    public class PaymentDetails
    {
        public int PaymentId { get; set; }
        public bool IsPaid { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}

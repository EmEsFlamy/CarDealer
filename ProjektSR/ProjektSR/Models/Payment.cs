namespace ProjektSR.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        public DateTime TranscationDate { get; set; }
    }
}

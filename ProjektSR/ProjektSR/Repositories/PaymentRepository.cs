using ProjektSR.Database;
using ProjektSR.Interfaces;
using ProjektSR.Models;

namespace ProjektSR.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public Payment? GetPaymentById(int id)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            return payment;
        }
    }
}

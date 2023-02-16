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

        public IEnumerable<Payment> GetAllUnpaid()
        {
            var payments = _context.Payments.Where(x => !x.IsPaid).AsEnumerable();
            if(payments is null) return Enumerable.Empty<Payment>();
            return payments;
        }

        public Payment? GetPaymentById(int id)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            return payment;
        }
    }
}

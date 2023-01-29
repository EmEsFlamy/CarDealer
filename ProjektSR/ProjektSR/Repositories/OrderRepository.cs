using Microsoft.AspNetCore.Hosting.Builder;
using ProjektSR.Database;
using ProjektSR.Interfaces;
using ProjektSR.Models;

namespace ProjektSR.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order? GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            return order;
        }
    }
}

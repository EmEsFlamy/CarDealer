using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);

        public Order? GetOrderById(int id);
    }
}

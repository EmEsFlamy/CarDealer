using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);

        public Order? GetOrderById(int id);
    }
}

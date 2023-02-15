using Microsoft.AspNetCore.Mvc;
using ProjektSR.Interfaces;
using ProjektSR.Models;
using ProjektSR.Repositories;

namespace ProjektSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;

        public OrderController(IOrderRepository orderRepository, 
            IPaymentRepository paymentRepository)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            var o = _orderRepository.CreateOrder(order);
            var payment = new Payment
            {
                OrderId = o.Id,
                UserId = o.UserId
            };
            _paymentRepository.CreatePayment(payment);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetOrderById([FromQuery]int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order is null) return BadRequest("Order does not exist!");
            return Ok(order);
        }
    }
}

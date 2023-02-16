using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektSR.Interfaces;
using ProjektSR.Models;
using ProjektSR.Repositories;

namespace ProjektSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICarRepository _carRepository;

        public OrderController(IOrderRepository orderRepository, 
            IPaymentRepository paymentRepository, ICarRepository carRepository)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _carRepository = carRepository;
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            var o = _orderRepository.CreateOrder(order);
            var car = _carRepository.GetCarById(o.CarId);
            var payment = new Payment
            {
                OrderId = o.Id,
                UserId = o.UserId,
                TotalPrice = (int)(o.EndDate - o.StartDate).TotalDays * (int)car.Price
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

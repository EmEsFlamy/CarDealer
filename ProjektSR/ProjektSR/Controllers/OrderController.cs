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

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _orderRepository.CreateOrder(order);
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

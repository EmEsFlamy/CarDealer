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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpPost]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            _paymentRepository.CreatePayment(payment);
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult GetPaymentById([FromQuery] int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            if (payment is null) return BadRequest("Payment does not exist!");
            return Ok(payment);
        }

        [HttpGet("GetAllUnpaid")]
        [Authorize(Roles = "1")]
        public IActionResult GetAllUnpaid() 
        {
            var payments = _paymentRepository.GetAllUnpaid();
            return Ok(payments);
        }
    }
}

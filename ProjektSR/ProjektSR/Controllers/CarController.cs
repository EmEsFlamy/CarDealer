using Microsoft.AspNetCore.Mvc;
using ProjektSR.Interfaces;
using ProjektSR.Models;

namespace ProjektSR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpPost]
        public IActionResult CreateCar([FromBody] Car car)
        {
            _carRepository.CreateCar(car);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car is null) return BadRequest("Car does not exist!");
            return Ok(car);
        }
    }
}

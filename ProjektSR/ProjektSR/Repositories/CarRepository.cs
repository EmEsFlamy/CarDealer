using ProjektSR.Database;
using ProjektSR.Interfaces;
using ProjektSR.Models;

namespace ProjektSR.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Car? GetCarById(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            return car;
        }
    }
}

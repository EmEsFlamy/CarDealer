using ProjektSR.Models;
using ProjektSR.Models.Enums;

namespace ProjektSR.Interfaces
{
    public interface ICarRepository
    {
        public void CreateCar(Car car);

        public Car? GetCarById(int id);

        public IEnumerable<Car> GetCarsByType(CarTypeEnum carType);


    }
}

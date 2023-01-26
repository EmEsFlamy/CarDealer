using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface ICarRepository
    {
        public void CreateCar(Car car);

        public Car? GetCarById(int id);




    }
}

using CarStore.App.Models;

namespace CarStore.App.Services
{
    public interface ICarServices
    {
        List<Models.Car> GetAllCars();
        Models.Car GetCarById(int id);
        Models.Car Modify(int id, Car newCar);
        Models.Car Create(Car createCar);
        void Delete(int id);
        
    }
}

using CarStore.App.Data;
using CarStore.App.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.App.Services
{
    public class CarsServices : ICarServices
    {
        //deklarimi i appdbcontext
        private AppDbContext _context;
        public CarsServices(AppDbContext context)
        {
            _context = context;
        }


        public string GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            var allCars = _context.Cars.Include(n => n.Company).ToList();
            return allCars;
        }

        public Car GetCarById(int id)
        {
            var newCar = _context.Cars
                .FirstOrDefault(n => n.Id == id);

            return newCar;
        }

        public Car Modify(int id, Car newCar)
        {
            var result = _context.Cars.FirstOrDefault(n => n.Id == id);
            result.ModelName = newCar.ModelName;
            result.Company = newCar.Company;
            result.YearOfManufacture = newCar.YearOfManufacture;
            result.MotorPower = newCar.MotorPower;
            result.MaximumSpeed = newCar.MaximumSpeed;
            result.URLimg = newCar.URLimg; 

            _context.Cars.Update(result);
            _context.SaveChanges();
            return newCar;
        }

        public void Delete(int id)
        {
            var result = _context.Cars.FirstOrDefault(n => n.Id == id);
            _context.Cars.Remove(result);
            _context.SaveChanges();
        }

        

        public Car Create(Car createCar)
        {
            _context.Cars.Add(createCar);
            _context.SaveChanges();
            return createCar;
        }
    }

}
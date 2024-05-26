using CompanyStore.App.Services;
using CarStore.App.Models;
using CarStore.App.Services;
using CarStore.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.App.Controllers
{
    public class CarController : Controller
    {
        private ICarServices _carServices;
        private ICompanyServices _companyServices;

        public CarController(ICarServices carsServices, ICompanyServices companyServices)
        {
            _carServices = carsServices;
            _companyServices = companyServices;
        }
        public IActionResult Index()
        {
            var allCars = _carServices.GetAllCars();
            return View(allCars);
        }

        public IActionResult Details(int id)
        {
            var car = _carServices.GetCarById(id);


            return View(car);
        }
        //Create
        public IActionResult Create()
        {
            var allCompanies = _companyServices.GetAllCompanies();
            var newPostCarVM = new PostCarVM()
            {
                Companies = allCompanies
            };

            return View(newPostCarVM);
        }

        [HttpPost]
        public IActionResult CreateConfirm(PostCarVM createCar)
        {
            ModelState.Remove("Car.Company");
            if (!ModelState.IsValid)
            {
                return View(createCar);
            }
            _carServices.Create(createCar.Car);
            return RedirectToAction(nameof(Index));
        }





        //Get: Cars/Modify/1
        public IActionResult Modify(int id)
        {
            var carDetails = _carServices.GetCarById(id);
            if (carDetails == null) return View("NotFound");
            return View(carDetails);
        }

        [HttpPost]
        public IActionResult ModifyConfirm(int id , [Bind("Model Name,Company Name,Year Of Manufacture,Motor Power,Maximum Speed,URLimg")] Car  newcar)
        {
            if (!ModelState.IsValid)
            {
                return View(newcar);
            }
            _carServices.Modify(id, newcar);
            return RedirectToAction(nameof(Index));
        }
        ///delete mv
        public IActionResult Delete(int id )
        {
            var carDetails =  _carServices.GetCarById(id);
            if (carDetails == null) return View("NotFound");
            return View(carDetails);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirm(int id)
        {
            var carDetails =  _carServices.GetCarById(id);
            if (carDetails == null) return View("NotFound");

            _carServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

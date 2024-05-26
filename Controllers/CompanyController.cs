using CompanyStore.App.Services;
using CarStore.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyStore.App.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companiesServices) => _companyServices = companiesServices;
        public IActionResult Index()
        {
            var allCompanies = _companyServices.GetAllCompanies();

            return View(allCompanies);
        }

        public IActionResult Details(int id)
        {
            var company = _companyServices.GetCompanyById(id);


            return View(company);
        }
        //Create
        public IActionResult Create()
        {
            var newCompany = new Company();
            return View(newCompany);
        }

        [HttpPost]
        public IActionResult CreateConfirm([Bind("Company Name")] Company createCompany)
        {
            if (!ModelState.IsValid)
            {
                return View(createCompany);
            }
            _companyServices.Create(createCompany);
            return RedirectToAction(nameof(Index));
        }



        //Get: Authors/Modify/1
        public IActionResult Modify(int id)
        {
            var companyDetails = _companyServices.GetCompanyById(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        [HttpPost]
        public IActionResult ModifyConfirm(int id , [Bind("Company Name")] Company newcompany)
        {
            if (!ModelState.IsValid)
            {
                return View(newcompany);
            }
            _companyServices.Modify(id, newcompany);
            return RedirectToAction(nameof(Index));
        }
        ///delete mv
        public IActionResult Delete(int id )
        {
            var companyDetails = _companyServices.GetCompanyById(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public  IActionResult DeleteConfirm(int id)
        {
            var companyDetails = _companyServices.GetCompanyById(id);
            if (companyDetails == null) return View("NotFound");

            _companyServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using CarStore.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarStore.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

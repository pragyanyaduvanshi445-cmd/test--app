using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace test__app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
    }
}

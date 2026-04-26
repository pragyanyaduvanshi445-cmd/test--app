using Microsoft.AspNetCore.Mvc;

namespace test__app.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
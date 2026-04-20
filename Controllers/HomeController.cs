using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test__app.Models;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}

.\repo\Views\Home\Login.cshtml:
---
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login</title>
</head>
<body>
    <h2>Login</h2>
    <form method="post" action="/Home/Login">
        <div>
            <label for="username">Username:</label>
            <input type="text" id="username" name="username" />
        </div>
        <div>
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" />
        </div>
        <button type="submit">Login</button>
    </form>
</body>
</html>
---
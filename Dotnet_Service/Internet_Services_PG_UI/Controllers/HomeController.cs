using Microsoft.AspNetCore.Mvc;

namespace Internet_Services_PG_UI.Controllers
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
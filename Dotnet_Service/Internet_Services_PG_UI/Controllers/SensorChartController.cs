using Microsoft.AspNetCore.Mvc;

namespace Internet_Services_PG_UI.Controllers
{
    public class SensorChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
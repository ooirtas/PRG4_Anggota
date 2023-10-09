using Microsoft.AspNetCore.Mvc;

namespace PRG4_M3_P1_052.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

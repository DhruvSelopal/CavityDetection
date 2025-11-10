using Microsoft.AspNetCore.Mvc;

namespace CavityDetection.Controllers
{
    public class RasberyPiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

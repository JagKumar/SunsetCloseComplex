using Microsoft.AspNetCore.Mvc;

namespace SSC.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

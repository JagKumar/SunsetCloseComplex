using Microsoft.AspNetCore.Mvc;

namespace SSC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

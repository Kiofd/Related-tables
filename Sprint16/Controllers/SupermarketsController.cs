using Microsoft.AspNetCore.Mvc;

namespace Sprint16.Controllers
{
    public class SupermarketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

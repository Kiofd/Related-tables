using Microsoft.AspNetCore.Mvc;

namespace Sprint16.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

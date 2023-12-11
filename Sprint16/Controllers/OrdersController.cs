using Microsoft.AspNetCore.Mvc;

namespace Sprint16.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

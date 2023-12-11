using Microsoft.AspNetCore.Mvc;

namespace Sprint16.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

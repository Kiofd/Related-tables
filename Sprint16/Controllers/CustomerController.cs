using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;

namespace Sprint16.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ShoppingContext _context;
        public CustomerController(ShoppingContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}

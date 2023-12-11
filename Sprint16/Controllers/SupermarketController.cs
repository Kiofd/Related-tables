using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;


namespace Sprint16.Controllers
{
    public class SupermarketController : Controller
    {
        private readonly ShoppingContext _context;
        public SupermarketController(ShoppingContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supermarkets.ToListAsync());
        }
        public async Task<IActionResult> Create(Supermarket supermarket)
        {
            return View(supermarket);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingContext _context;
        public ProductController(ShoppingContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> Create(Product product)
        {
            return View(product);
        }
        public async Task<IActionResult> View(int id)
        {
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
        // public async Task<IActionResult> Delete(int id)
        // {
        //     return View();
        // }
    }
}

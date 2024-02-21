using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;
using Sprint16.Repository;
using Sprint16.ViewModels;

namespace Sprint16.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingContext _context;
        UnitOfWork unitOfWork;

        public OrderController(ShoppingContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 10;

            var order = await _context.Orders
                .Include(o => o.Customers)
                .Include(o => o.Supermarkets)
                .OrderBy(o => o.OrderDate)
                .AsNoTracking()
                .ToListAsync();

            return View(order);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var orderDetails = await _context.OrderDetails
                .Include(o => o.Product)
                .Include(o => o.Order)
                .Where(o => o.OrderId == id)
                .AsNoTracking()
                .ToListAsync();
            
            return View(orderDetails);
        }

        [HttpGet]
        //feature to edit order details
        public async Task<IActionResult> EditDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Product)
                .Include(o => o.Order)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(int? id, OrderDetails orderDetails)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.OrderDetails
            .Include(o => o.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

            order = orderDetails;
            
            if (orderDetails == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<OrderDetails>(order,
                    "",
                    c => c.Quantity, c => c.ProductId))
            {
                try
                {
                    _context.OrderDetails.Update(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Try again, and if the problem persists " +
                                                 "see your system administrator.");
                }
            }

            return View(order);
        }
    }
}
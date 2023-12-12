using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.Repository;

namespace Sprint16.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ShoppingContext _context;
		UnitOfWork unitOfWork;
		public CustomerController(ShoppingContext context)
		{
			_context = context;
			unitOfWork = new UnitOfWork(context);

		}

		public async Task<IActionResult> Index()
		{
			var customers = await unitOfWork.Customers.GetAll();
			return View(customers);
		}

		public async Task<IActionResult> Create(Customer customer)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await unitOfWork.Customers.Create(customer);
					return RedirectToAction(nameof(Index));
				}
			}
			catch (DbUpdateException /* ex */)
			{
				//Log the error (uncomment ex variable name and write a log.
				ModelState.AddModelError("", "Unable to save changes. " +
					"Try again, and if the problem persists " +
					"see your system administrator.");
			}
			return View(customer);
		}


		//public IActionResult Create()
		//{
		//	return View();
		//}
	}
}

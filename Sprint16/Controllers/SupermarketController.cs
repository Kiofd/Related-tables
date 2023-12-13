using Microsoft.AspNetCore.Mvc;
using Sprint16.Data;
using Microsoft.EntityFrameworkCore;
using Sprint16.Models;
using Sprint16.Repository;
using Sprint16.ViewModels;


namespace Sprint16.Controllers
{
	public class SupermarketController : Controller
	{
		private readonly ShoppingContext _context;
		UnitOfWork unitOfWork;
		public SupermarketController(ShoppingContext context)
		{
			_context = context;
			unitOfWork = new UnitOfWork(context);
		}

		// TODO: + Add pagination to Supermarkets index page
		public async Task<IActionResult> Index(int? pageNumber)
		{
			const int pageSize = 3;
			return View(await PaginatedList<Supermarket>.CreateAsync(_context.Supermarkets.AsNoTracking(), pageNumber ?? 1, pageSize));
		}

		// TODO: + CRUD for Supermarkets
		[HttpGet]
		public IActionResult Create()
		{
			return View(new SupermarketViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> Create(SupermarketViewModel supermarket)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await unitOfWork.Supermarkets.Create(new Supermarket
					{
						Name = supermarket.Name,
						Address = supermarket.Address,
					});
					unitOfWork.Save();
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
			return View(supermarket);
		}

		[HttpGet]
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			int supermarketId = (int)id;
			Supermarket supermarket = await unitOfWork.Supermarkets.Get(supermarketId);
			if (supermarket == null)
				return NotFound();
			return View(new SupermarketViewModel
			{
				Name = supermarket.Name,
				Address = supermarket.Address,
			});
		}
		[HttpPost]
		public async Task<ActionResult> Edit(int? id, SupermarketViewModel supermarket)
		{
			if (id == null)
			{
				return NotFound();
			}
			int supermarketId = (int)id;
			var supermarketToUpdate = await unitOfWork.Supermarkets.Get(supermarketId);
			supermarketToUpdate.Name = supermarket.Name;
			supermarketToUpdate.Address = supermarket.Address;
			try
			{
				if (ModelState.IsValid)
				{
					await unitOfWork.Supermarkets.Update(supermarketToUpdate);
					unitOfWork.Save();
					return RedirectToAction(nameof(Index));
				}
				return View(supermarket);
			}
			catch (DbUpdateException /* ex */)
			{
				//Log the error (uncomment ex variable name and write a log.
				ModelState.AddModelError("", "Unable to save changes. " +
					"Try again, and if the problem persists " +
					"see your system administrator.");
			}
			return View(supermarket);
		}

		[HttpGet]
		public async Task<ActionResult> View(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			int supermarketId = (int)id;
			Supermarket supermarket = await unitOfWork.Supermarkets.Get(supermarketId);
			if (supermarket == null)
				return NotFound();
			ViewBag.SupermarketId = supermarketId;
			return View(new SupermarketViewModel
			{
				Name = supermarket.Name,
				Address = supermarket.Address,
			});
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
		{
			if (id == null)
			{
				return NotFound();
			}
			Supermarket supermarket = await unitOfWork.Supermarkets.Get((int)id);
			if (supermarket == null)
				return NotFound();
			if (saveChangesError.GetValueOrDefault())
			{
				ViewData["ErrorMessage"] =
					"Delete failed. Try again, and if the problem persists " +
					"see your system administrator.";
			}
			return View(new SupermarketViewModel
			{
				Name = supermarket.Name,
				Address = supermarket.Address,
			});
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			Supermarket supermarket = await unitOfWork.Supermarkets.Get((int)id);
			if (supermarket == null)
			{
				return RedirectToAction(nameof(Index));
			}
			try
			{
				await unitOfWork.Supermarkets.Delete((int)id);
				unitOfWork.Save();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateException /* ex */)
			{
				//Log the error (uncomment ex variable name and write a log.)
				return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
			}
		}

		protected override void Dispose(bool disposing)
		{
			unitOfWork.Dispose();
			base.Dispose(disposing);
		}
	}
}

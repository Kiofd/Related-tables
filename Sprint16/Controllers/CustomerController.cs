using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.Repository;
using Sprint16.ViewModels;
using System.Collections.Generic;

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

		// TODO: + Add the ability to sort the list of customers by the last name or address (in descending and ascending order)
		public async Task<IActionResult> Index(string sortOrder, string searchString)
		{
			ViewData["LastNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
			ViewData["AddressSortParm"] = sortOrder == "Address" ? "address_desc" : "Address";
			ViewData["CurrentFilter"] = searchString;
			var customers = await unitOfWork.Customers.GetAll();
			if (!String.IsNullOrEmpty(searchString))
			{
				searchString = searchString.ToLower();
				customers = customers.Where(s => s.Lname.ToLower().Contains(searchString)
									   || s.Fname.ToLower().Contains(searchString));
			}

			switch (sortOrder)
			{
				case "last_name_desc":
					customers = customers.OrderByDescending(s => s.Lname);
					break;
				case "Address":
					customers = customers.OrderBy(s => s.Address);
					break;
				case "address_desc":
					customers = customers.OrderByDescending(s => s.Address);
					break;
				default:
					customers = customers.OrderBy(s => s.Lname);
					break;
			}
			return View(customers);
		}

		// TODO: + CRUD for Customers
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.DiscountTypes = GetDiscountTypes();
			return View(new CustomerViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> Create(CustomerViewModel customer)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await unitOfWork.Customers.Create(new Customer
					{
						Lname = customer.Lname,
						Fname = customer.Fname,
						Address = customer.Address,
						Discount = customer.Discount
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
			return View(customer);
		}

		[HttpGet]
		public async Task<ActionResult> Edit(int id)
		{
			Customer customer = await unitOfWork.Customers.Get(id);
			if (customer == null)
				return NotFound();
			ViewBag.DiscountTypes = GetDiscountTypes();
			return View(new CustomerViewModel
			{
				Fname = customer.Fname,
				Lname = customer.Lname,
				Address = customer.Address,
				Discount = customer.Discount
			});
		}
		[HttpPost]
		public async Task<ActionResult> Edit(int? id, CustomerViewModel customer)
		{
			if (id == null)
			{
				return NotFound();
			}
			int customerId = (int)id;
			var customerToUpdate = await unitOfWork.Customers.Get(customerId);
			customerToUpdate.Lname = customer.Lname;
			customerToUpdate.Fname = customer.Fname;
			customerToUpdate.Address = customer.Address;
			customerToUpdate.Discount = customer.Discount;
			try
			{
				if (ModelState.IsValid)
				{
					await unitOfWork.Customers.Update(customerToUpdate);
					unitOfWork.Save();
					return RedirectToAction(nameof(Index));
				}
				return View(customer);
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

		[HttpGet]
		public async Task<ActionResult> View(int id)
		{
			Customer customer = await unitOfWork.Customers.Get(id);
			if (customer == null)
				return NotFound();
			ViewBag.CustomerId = id;
			return View(new CustomerViewModel
			{
				Fname = customer.Fname,
				Lname = customer.Lname,
				Address = customer.Address,
				Discount = customer.Discount
			});
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
		{
			if (id == null)
			{
				return NotFound();
			}
			Customer customer = await unitOfWork.Customers.Get((int)id);
			if (customer == null)
				return NotFound();
			if (saveChangesError.GetValueOrDefault())
			{
				ViewData["ErrorMessage"] =
					"Delete failed. Try again, and if the problem persists " +
					"see your system administrator.";
			}
			return View(new CustomerViewModel
			{
				Fname = customer.Fname,
				Lname = customer.Lname,
				Address = customer.Address,
				Discount = customer.Discount
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
			Customer customer = await unitOfWork.Customers.Get((int)id);
			if (customer == null)
			{
				return RedirectToAction(nameof(Index));
			}
			try
			{
				await unitOfWork.Customers.Delete((int)id);
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

		private SelectList GetDiscountTypes()
		{
			Discount[] categories = (Discount[])Enum.GetValues(typeof(Discount));
			var categoriesWithNames = from value in categories
									  select new { DiscountType = value, DiscountValue = (int)value };
			return new SelectList(categoriesWithNames, "DiscountValue", "DiscountType");
		}
	}
}
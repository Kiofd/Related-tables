using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;
using Sprint16.Service;

namespace Sprint16.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDataService<Customer> _dataService;
        public CustomerController(IDataService<Customer> dataService)
        {
            _dataService = dataService;
        }
        public async Task<IActionResult> Index(string? searchString)
        {
            var customer = await _dataService.GetSmth();
            if(!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                customer = customer.Where(c => c.Lname.ToLower().Contains(searchString)|| c.Fname.ToLower().Contains(searchString));
            }            
            return View(customer);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _dataService.Get(id);
            
            return View(customer);
        }
    }
}

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
        public async Task<IActionResult> Index()
        {

            return View(await );
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}

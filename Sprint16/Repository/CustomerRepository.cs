using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Repository
{
	public class CustomerRepository : IRepository<Customer>
	{
		private ShoppingContext db;

		public CustomerRepository(ShoppingContext context) => this.db = context;

		public async Task<IEnumerable<Customer>> GetAll() => await db.Customers.ToListAsync();

		public async Task<Customer> Get(int id) => await db.Customers.FindAsync(id);

		public async Task Create(Customer item) => await db.Customers.AddAsync(item);

		public async Task Update(Customer item) => await Task.Factory.StartNew(() => db.Entry(item).State = EntityState.Modified);

		public async Task Delete(int id)
		{
			Customer item = await db.Customers.FindAsync(id);
			if (item != null)
				db.Customers.Remove(item);
		}
	}
}

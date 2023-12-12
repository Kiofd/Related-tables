using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Repository
{
	public class OrderRepository : IRepository<Order>
	{
		private ShoppingContext db;

		public OrderRepository(ShoppingContext context) => this.db = context;

		public async Task<IEnumerable<Order>> GetAll() => await db.Orders.ToListAsync();

		public async Task<Order> Get(int id) => await db.Orders.FindAsync(id);

		public async Task Create(Order item) => await db.Orders.AddAsync(item);

		public async Task Update(Order item) => await Task.Factory.StartNew(() => db.Entry(item).State = EntityState.Modified);

		public async Task Delete(int id)
		{
			Order item = await db.Orders.FindAsync(id);
			if (item != null)
				db.Orders.Remove(item);
		}
	}
}

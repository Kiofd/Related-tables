using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Repository
{
	public class OrderDetailsRepository : IRepository<OrderDetails>
	{
		private ShoppingContext db;

		public OrderDetailsRepository(ShoppingContext context) => this.db = context;

		public async Task<IEnumerable<OrderDetails>> GetAll() => await db.OrderDetails.ToListAsync();

		public async Task<OrderDetails> Get(int id) => await db.OrderDetails.FindAsync(id);

		public async Task Create(OrderDetails item) => await db.OrderDetails.AddAsync(item);

		public async Task Update(OrderDetails item) => await Task.Factory.StartNew(() => db.Entry(item).State = EntityState.Modified);

		public async Task Delete(int id)
		{
			OrderDetails item = await db.OrderDetails.FindAsync(id);
			if (item != null)
				db.OrderDetails.Remove(item);
		}
	}
}

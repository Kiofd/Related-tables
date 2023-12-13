using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Repository
{
	public class SupermarketRepository : IRepository<Supermarket>
	{
		private ShoppingContext db;

		public SupermarketRepository(ShoppingContext context) => this.db = context;

		public async Task<IEnumerable<Supermarket>> GetAll() => await db.Supermarkets.ToListAsync();

		public async Task<Supermarket> Get(int id) => await db.Supermarkets.FindAsync(id);

		public async Task Create(Supermarket item) => await db.Supermarkets.AddAsync(item);

		public async Task Update(Supermarket item) => await Task.Factory.StartNew(() => db.Entry(item).State = EntityState.Modified);

		public async Task Delete(int id)
		{
			Supermarket item = await db.Supermarkets.FindAsync(id);
			if (item != null)
				db.Supermarkets.Remove(item);
		}
	}
}

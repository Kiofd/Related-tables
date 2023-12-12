using Microsoft.EntityFrameworkCore;
using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Repository
{
	public class ProductRepository : IRepository<Product>
	{
		private ShoppingContext db;

		public ProductRepository(ShoppingContext context) => this.db = context;

		public async Task<IEnumerable<Product>> GetAll() => await db.Products.ToListAsync();

		public async Task<Product> Get(int id) => await db.Products.FindAsync(id);

		public async Task Create(Product item) => await db.Products.AddAsync(item);

		public async Task Update(Product item) => await Task.Factory.StartNew(() => db.Entry(item).State = EntityState.Modified);

		public async Task Delete(int id)
		{
			Product item = await db.Products.FindAsync(id);
			if (item != null)
				db.Products.Remove(item);
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Sprint16.Models;

namespace Sprint16.Data
{
	public class ShoppingContext : DbContext
	{
		public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated();
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Supermarket> Supermarkets { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
	}
}

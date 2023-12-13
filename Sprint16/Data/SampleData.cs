using Sprint16.Models;

namespace Sprint16.Data
{
	public class SampleData
	{
		public static void Initialize(ShoppingContext context)
		{
			if (context.Products.Any() || context.Customers.Any() || context.Supermarkets.Any() || context.Orders.Any())
			{
				return;
			}

			var products = new Product[]
			{
				new Product { Name = "Banan", Price = 30.0f },
				new Product { Name = "Apple", Price = 20.50f },
				new Product { Name = "Morshinska", Price = 9.30f }
			};
			context.Products.AddRange(products);
			context.SaveChanges();

			var customers = new Customer[]
			{
				new Customer { Fname = "Volodya", Lname = "Myk", Address = "Ivano-Frankivsk", Discount = Discount.O },
				new Customer { Fname = "Hlib", Lname = "Bond", Address = "Dnipro", Discount = Discount.R },
				new Customer { Fname = "Maksym", Lname = "Seer", Address = "Kyiv", Discount = Discount.V }
			};
			context.Customers.AddRange(customers);
			context.SaveChanges();

			var supermarkets = new Supermarket[]
			{
				new Supermarket { Name = "Atb", Address = "Mazepy str" },
				new Supermarket { Name = "Silpo", Address = "Shevchenka str" },
				new Supermarket { Name = "Comfy", Address = "Parkova str" }
			};
			context.Supermarkets.AddRange(supermarkets);
			context.SaveChanges();

			var orders = new Order[]
			{
				new Order { CustomerId = 1, SupermarketId = 1, OrderDate = new DateTime(2023, 3, 4) },
				new Order { CustomerId = 2, SupermarketId = 2, OrderDate = new DateTime(2023, 5, 27) },
				new Order { CustomerId = 3, SupermarketId = 3, OrderDate = new DateTime(2023, 1, 2) }
			};
			context.Orders.AddRange(orders);
			context.SaveChanges();

			var orderDetails = new OrderDetails[]
			{
				new OrderDetails { OrderId = 1, ProductId = 1, Quantity = 5 },
				new OrderDetails { OrderId = 2, ProductId = 3, Quantity = 4 },
				new OrderDetails { OrderId = 3, ProductId = 2, Quantity = 1 }
			};
			context.OrderDetails.AddRange(orderDetails);
			context.SaveChanges();
		}
	}
}

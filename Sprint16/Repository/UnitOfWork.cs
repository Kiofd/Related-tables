using Sprint16.Data;

namespace Sprint16.Repository
{
	public class UnitOfWork : IDisposable
	{
		private ShoppingContext db;
        public UnitOfWork(ShoppingContext shoppingContext)
        {
            db = shoppingContext;
        }
		private ProductRepository productRepository;
		private SupermarketRepository supermarketRepository;
		private OrderRepository orderRepository;
		private OrderDetailsRepository orderDetailsRepository;

		//public CustomerRepository Customers
		//{
		//	get
		//	{
		//		if (customerRepository == null)
		//			customerRepository = new CustomerRepository(db);
		//		return customerRepository;
		//	}
		//}

		public ProductRepository Products
		{
			get
			{
				if (productRepository == null)
					productRepository = new ProductRepository(db);
				return productRepository;
			}
		}

		public SupermarketRepository Supermarkets
		{
			get
			{
				if (supermarketRepository == null)
					supermarketRepository = new SupermarketRepository(db);
				return supermarketRepository;
			}
		}

		public OrderDetailsRepository OrdersDetails
		{
			get
			{
				if (orderDetailsRepository == null)
					orderDetailsRepository = new OrderDetailsRepository(db);
				return orderDetailsRepository;
			}
		}

		public OrderRepository Orders
		{
			get
			{
				if (orderRepository == null)
					orderRepository = new OrderRepository(db);
				return orderRepository;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

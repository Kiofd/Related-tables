using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Service
{
    public class DataService : IDataService
    {
        private readonly ShoppingContext _dbContext;
        public DataService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task <IEnumerable<Customer>> GetCustomers() // for example
        {
            return _dbContext.Customers.ToList(); 
        }
        public async Task AddProduct(Product product) // for example 
        {
             _dbContext.Products.Add(product);
             await _dbContext.SaveChangesAsync();             
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetails>> GetOrdersDetails()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supermarket>> GetSupermarkets()
        {
            throw new NotImplementedException();
        }
        public async Task GetProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public async Task RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

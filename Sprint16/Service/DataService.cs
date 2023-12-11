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

     
        public IEnumerable<Customer> GetCustomers() // for example
        {
            return _dbContext.Customers.ToList(); 
        }
        public void AddProduct(Product product) // for example 
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetOrdersDetails()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supermarket> GetSupermarkets()
        {
            throw new NotImplementedException();
        }

        
        public void GetProduct(Product product)
        {
            throw new NotImplementedException();
        }

       
        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

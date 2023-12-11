using Sprint16.Models;

namespace Sprint16.Service
{
    public interface IDataService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Supermarket>> GetSupermarkets();
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<OrderDetails>> GetOrdersDetails();

        // For example. I created CRUD operation for Product. In next time we can add methods whatever u need.
        // U can remove rest methods 
        Task AddProduct(Product product);
        Task RemoveProduct(Product product);
        Task UpdateProduct(Product product);
        Task GetProduct(Product product);
    }
}

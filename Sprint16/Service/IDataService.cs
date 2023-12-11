using Sprint16.Models;

namespace Sprint16.Service
{
    public interface IDataService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Supermarket> GetSupermarkets();
        IEnumerable<Order> GetOrders();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<OrderDetails> GetOrdersDetails();

        // For example. I created CRUD operation for Product. In next time we can add methods whatever u need.
        // U can remove rest methods 
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);
        void GetProduct(Product product);
    }
}

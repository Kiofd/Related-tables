using Sprint16.Models;

namespace Sprint16.Service
{
    public interface IDataService<T>where T : class
    {
        //Task<IEnumerable<Product>> GetProducts();
        //Task<IEnumerable<Supermarket>> GetSupermarkets();
        //Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<T>> GetSmth();

     
        Task Add(T smth);
        Task Remove(T product);
        Task Update(T product);
        Task Get(T product);
    }
}

using Sprint16.Models;

namespace Sprint16.Service
{
    public interface IDataService<T>where T : class
    {
        Task<IEnumerable<T>> GetSmth();

        Task Add(T smth);
        Task Remove(int smthId);
        Task Update(T smth);
        Task<Customer> Get(int smthId);
    }
}

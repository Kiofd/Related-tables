using Sprint16.Data;
using Sprint16.Models;

namespace Sprint16.Service
{
    public class CustomerService : IDataService<Customer>
    {
        private readonly ShoppingContext _dbContext;
        public CustomerService(ShoppingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Customer smth)
        {
            _dbContext.Add(smth);
            await _dbContext.SaveChangesAsync();
        }

        public Task Get(Customer product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetSmth()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Customer product)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer product)
        {
            throw new NotImplementedException();
        }
    }
}

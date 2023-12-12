using Microsoft.EntityFrameworkCore;
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

        public Task<Customer> Get(int customerID)
        {
            return _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerID);
        }

        public async Task<IEnumerable<Customer>> GetSmth()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            try
            {
                _dbContext.Remove(customer);
            }
            catch (Exception)
            {
                throw new Exception("Object is null");
            }
            finally { _dbContext.SaveChanges(); }
        }

        public async Task Update(Customer customerUpdate)
        {
            //public async Task Update(Customer item) => await Task.Factory.StartNew(() => db.Entry(item).State = EntityState.Modified);
            var existingCustomer = await _dbContext.Customers.FindAsync(customerUpdate.Id);
            try
            {
                existingCustomer.Fname = customerUpdate.Fname;
                existingCustomer.Lname = customerUpdate.Lname;
                existingCustomer.Address = customerUpdate.Address;
                existingCustomer.Discount = customerUpdate.Discount;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Customer not found", new Exception());
            }
            await _dbContext.SaveChangesAsync(); 
        }

    }
}

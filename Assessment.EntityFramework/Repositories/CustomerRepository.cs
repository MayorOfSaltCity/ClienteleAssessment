using Assessment.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.EntityFramework.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public Task<bool> CustomerExists(int id)
        {
            return _context.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync(int pageSize, int pageNumber)
        {
            return await _context.Customers
                .Include(c => c.Address)
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}

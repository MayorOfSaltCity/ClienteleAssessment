using Assessment.EntityFramework.Models;

namespace Assessment.EntityFramework.Services
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync(int pageSize, int pageNumber);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
    }
}

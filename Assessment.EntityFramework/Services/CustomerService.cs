using Assessment.EntityFramework.Models;

namespace Assessment.EntityFramework.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IAddressRepository addressRepository) : ICustomerService
    {
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            // check if the customer has an address
            if (customer.Address != null)
            {
                // check if the address is already in the database
                var address = await addressRepository.GetAddressAsync(customer.Address.Id);
                if (address == null)
                {
                    // create the address
                    address = await addressRepository.CreateAddressAsync(customer.Address);
                }
                // set the address id
                customer.AddressId = address.Id;
            }

            // create the customer
            return await customerRepository.CreateCustomerAsync(customer);
        }

        public Task DeleteCustomerAsync(int id)
        {
            // delete the customer
            return customerRepository.DeleteCustomerAsync(id);
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            // get the customer
            return customerRepository.GetCustomerAsync(id);
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync(int pageSize, int pageNumber)
        {
            // get the customers
            return customerRepository.GetCustomersAsync(pageSize, pageNumber);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            // check if the customer has an address
            if (customer.Address != null)
            {
                // check if the address is already in the database
                var address = await addressRepository.GetAddressAsync(customer.Address.Id);
                if (address == null)
                {
                    // create the address
                    address = await addressRepository.CreateAddressAsync(customer.Address);
                }
                // set the address id
                customer.AddressId = address.Id;
            }

            // update the customer
            return await customerRepository.UpdateCustomerAsync(customer);
        }
    }
}

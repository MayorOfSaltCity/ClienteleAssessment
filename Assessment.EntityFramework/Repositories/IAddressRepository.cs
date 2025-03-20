using Assessment.EntityFramework.Models;

namespace Assessment.EntityFramework.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(int id);
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task<Address> CreateAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
        Task<Address?> SearchAddressAsync(string searchString);
    }
}

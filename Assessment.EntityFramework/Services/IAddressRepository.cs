﻿using Assessment.EntityFramework.Models;

namespace Assessment.EntityFramework.Services
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(int id);
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task<Address> CreateAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
    }
}

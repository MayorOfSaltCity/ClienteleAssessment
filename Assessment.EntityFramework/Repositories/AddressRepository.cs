using Assessment.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.EntityFramework.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Address?> GetAddressAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address?> CreateAddressAsync(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            // find the address
            var returnAddress = await _context.Addresses.FindAsync(address.Id);
            return returnAddress;
        }

        public async Task<Address?> UpdateAddressAsync(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);
            var addressId = address.Id;
            // find the address
            var existingAddress = await _context.Addresses.FindAsync(addressId);
            if (existingAddress == null)
            {
                throw new ArgumentException("Address not found", nameof(address));
            }

            // update the address
            _context.Entry(existingAddress).CurrentValues.SetValues(address);

            await _context.SaveChangesAsync();

            // get the updated address
            var returnAddress = await _context.Addresses.FindAsync(addressId);
            return returnAddress!;
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id) ?? throw new ArgumentException("Address not found", nameof(id));
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address?> SearchAddressAsync(string searchString)
        {
            // search for the address using a levenstein distance algorithm
            var addresses = await _context.Addresses.ToListAsync();
            var minDistance = int.MaxValue;
            Address? closestAddress = null;
            Parallel.For(0, addresses.Count,  i =>
            {
                var distance = LevenshteinDistance(searchString, addresses[i].SearchString());
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestAddress = addresses[i];
                }
            });

            return closestAddress;
        }

        private int LevenshteinDistance(string s, string t)
        {
            // calculate the levenshtein distance between two strings
            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (var i = 0; i <= n; d[i, 0] = i++)
            {
                d[i, 0] = i;
            }

            for (var j = 0; j <= m; d[0, j] = j++)
            {
                d[0, j] = j;
            }

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    var cost = t[j - 1] == s[i - 1] ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }
    }
}

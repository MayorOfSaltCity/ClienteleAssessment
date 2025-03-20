using System.ComponentModel.DataAnnotations;

namespace Assessment.EntityFramework.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required, MaxLength(100),EmailAddress]
        public string? Email { get; set; }
        [MaxLength(20),Phone]
        public string? Phone { get; set; }
        public Address? Address { get; set; }
        public int AddressId { get; set; }
    }

    public class Address
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string? Street { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(100)]
        public string? Province { get; set; }
        [MaxLength(10)]
        public string? PostalCode { get; set; }
    }
}

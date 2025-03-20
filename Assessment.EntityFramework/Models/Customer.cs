using System.ComponentModel.DataAnnotations;
using System.Text;

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
        public Address? Address { get; set; } = new Address();
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

        public string AsDisplayString
        {
            get
            {
                // create string builder
                var sb = new StringBuilder();
                // append street by line so we get a nicely formatted address
                sb.AppendLine(Street);
                // append city
                sb.AppendLine(City);
                // append province
                sb.AppendLine(Province);
                // append postal code
                sb.Append(PostalCode);
                // return the string
                return sb.ToString();
            }
        }

        internal string SearchString()
        {
            return string.Concat(new { Street, City, Province, PostalCode });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Tests
{
    using Assessment.EntityFramework.Models;
    public class CustomerControllerTests
    {
        public CustomerControllerTests() { }

        public async Task GetCustomer_ReturnsCustomer_WhenCalled()
        {
            // arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Email = ""
            };
        }
    }
}

using Assessment.EntityFramework.Models;
using Assessment.EntityFramework.Repositories;
using Assessment.EntityFramework.Services;
using Bogus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Tests
{
    public class CustomerServiceTests
    {
        public CustomerServiceTests() { }

        [Fact]
        public async Task GetCustomer_ReturnsCustomer_WhenCalled()
        {
            // Arrange customer using Faker
            var customer = new Faker<Customer>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Phone, f => f.Person.Phone)
                .RuleFor(c => c.Address, f => new Address
                {
                    City = f.Address.City(),
                    PostalCode = f.Address.ZipCode(),
                    Province = f.Address.State(),
                    Street = f.Address.StreetAddress()
                }).Generate();

            CustomerRepository.Setup(x => x.GetCustomerAsync(1)).ReturnsAsync(customer);

            // Act
            var result = await CustomerService.GetCustomerAsync(1);
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.Email, result.Email);
            Assert.Equal(customer.Address.City, result.Address.City);
            Assert.Equal(customer.Address.PostalCode, result.Address.PostalCode);
            Assert.Equal(customer.Address.Province, result.Address.Province);
            Assert.Equal(customer.Address.Street, result.Address.Street);
        }

        [Fact]
        public async Task GetCustomers_ReturnsCustomers_WhenCalled()
        {
            // Arrange
            var customers = Customers;

            CustomerRepository.Setup(x => x.GetCustomersAsync(10, 1)).ReturnsAsync(customers);

            // Act

            var result = await CustomerService.GetCustomersAsync(10, 1);
            Assert.NotNull(result);
            Assert.Equal(customers.Count(), result.Count());

            for (int i = 0; i < customers.Count(); i++)
            {
                Assert.Equal(customers.ElementAt(i).Id, result.ElementAt(i).Id);
                Assert.Equal(customers.ElementAt(i).Name, result.ElementAt(i).Name);
                Assert.Equal(customers.ElementAt(i).Email, result.ElementAt(i).Email);
                Assert.NotNull(result.ElementAt(i).Address);

                Assert.Equal(customers.ElementAt(i).Address.City, result.ElementAt(i).Address.City);
                Assert.Equal(customers.ElementAt(i).Address.PostalCode, result.ElementAt(i).Address.PostalCode);
                Assert.Equal(customers.ElementAt(i).Address.Province, result.ElementAt(i).Address.Province);
                Assert.Equal(customers.ElementAt(i).Address.Street, result.ElementAt(i).Address.Street);
            }
        }

        [Fact]
        public async Task CreateCustomer_ReturnsCustomer_WhenCalled()
        {
            // Arrange customer usinf faker
            var customer = new Faker<Customer>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Phone, f => f.Person.Phone)
                .RuleFor(c => c.Address, f => new Address
                {
                    City = f.Address.City(),
                    PostalCode = f.Address.ZipCode(),
                    Province = f.Address.State(),
                    Street = f.Address.StreetAddress()
                }).Generate();

            AddressRepository.Setup(x => x.GetAddressAsync(customer.Address.Id)).ReturnsAsync(customer.Address);
            AddressRepository.Setup(x => x.CreateAddressAsync(customer.Address)).ReturnsAsync(customer.Address);
            CustomerRepository.Setup(x => x.CreateCustomerAsync(customer)).ReturnsAsync(customer);

            // Act
            var result = await CustomerService.CreateCustomerAsync(customer);
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.Email, result.Email);
            Assert.Equal(customer.Address.City, result.Address.City);
            Assert.Equal(customer.Address.PostalCode, result.Address.PostalCode);
            Assert.Equal(customer.Address.Province, result.Address.Province);
            Assert.Equal(customer.Address.Street, result.Address.Street);
        }

        [Fact]
        public async Task UpdateCustomer_ReturnsCustomer_WhenCalled()
        {
            // Arrange using Faker
            var customer = new Faker<Customer>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Phone, f => f.Person.Phone)
                .RuleFor(c => c.Address, f => new Address
                {
                    City = f.Address.City(),
                    PostalCode = f.Address.ZipCode(),
                    Province = f.Address.State(),
                    Street = f.Address.StreetAddress()
                }).Generate();

            AddressRepository.Setup(x => x.GetAddressAsync(customer.Address.Id)).ReturnsAsync(customer.Address);
            AddressRepository.Setup(x => x.CreateAddressAsync(customer.Address)).ReturnsAsync(customer.Address);
            CustomerRepository.Setup(x => x.UpdateCustomerAsync(customer)).ReturnsAsync(customer);

            // Act
            var result = await CustomerService.UpdateCustomerAsync(customer);
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.Email, result.Email);
            Assert.Equal(customer.Address.City, result.Address.City);
            Assert.Equal(customer.Address.PostalCode, result.Address.PostalCode);
            Assert.Equal(customer.Address.Province, result.Address.Province);
            Assert.Equal(customer.Address.Street, result.Address.Street);
        }

        [Fact]
        public async Task DeleteCustomer_DeletesCustomer_WhenCalled()
        {
            // Arrange
            var customer = new Faker<Customer>()
                .RuleFor(c => c.Id, f => f.IndexFaker)
                .RuleFor(c => c.Name, f => f.Person.FullName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.Phone, f => f.Person.Phone)
                .RuleFor(c => c.Address, f => new Address
                {
                    City = f.Address.City(),
                    PostalCode = f.Address.ZipCode(),
                    Province = f.Address.State(),
                    Street = f.Address.StreetAddress()
                }).Generate();

            CustomerRepository.Setup(x => x.DeleteCustomerAsync(customer.Id)).Returns(Task.CompletedTask);

            // Act
            await CustomerService.DeleteCustomerAsync(customer.Id);
            CustomerRepository.Verify(x => x.DeleteCustomerAsync(customer.Id), Times.Once);
        }

        protected Mock<ICustomerRepository> CustomerRepository => _customerRepository ??= new Mock<ICustomerRepository>();
        protected Mock<IAddressRepository> AddressRepository => _addressRepository ??= new Mock<IAddressRepository>();
        protected CustomerService CustomerService => _customerService ??= new CustomerService(CustomerRepository.Object, AddressRepository.Object);
        protected IEnumerable<Customer> Customers
        {
            get
            {
                if (customers != null && customers.Count() > 0)
                {
                    return customers;
                }
                else
                {
                    var customerFaker = new Faker<Customer>()
                        .RuleFor(c => c.Id, f => f.IndexFaker)
                       .RuleFor(c => c.Name, f => f.Person.FullName)
                        .RuleFor(c => c.Email, f => f.Person.Email)
                        .RuleFor(c => c.Phone, f => f.Person.Phone)
                        .RuleFor(c => c.Address, f => new Address
                        {
                            City = f.Address.City(),
                            PostalCode = f.Address.ZipCode(),
                            Province = f.Address.State(),
                            Street = f.Address.StreetAddress()
                        });

                    customers = customerFaker.Generate(20);
                    return customers;
                }
            }
        }


        private CustomerService _customerService;
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<IAddressRepository> _addressRepository;
        private IEnumerable<Customer> customers;

    }
}

using Assessment.EntityFramework.Repositories;
using Assessment.EntityFramework.Services;

namespace Assessment.EntityFramework.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomerServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }

    }
}

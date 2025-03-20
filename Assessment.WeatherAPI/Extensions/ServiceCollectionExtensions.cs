using Assessment.WeatherAPI.Repositories;
using Assessment.WeatherAPI.Services;

namespace Assessment.WeatherAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeatherServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<HttpClient, HttpClient>();
            return services;
        }
    }
}

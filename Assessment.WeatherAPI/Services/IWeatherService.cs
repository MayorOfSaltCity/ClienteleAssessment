
using Assessment.WeatherAPI.Models;

namespace Assessment.WeatherAPI.Services
{
    public interface IWeatherService
    {
        Task<WeatherData?> GetWeatherAsync(string searchCity);
    }
}

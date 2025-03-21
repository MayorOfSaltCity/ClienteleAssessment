using Assessment.WeatherAPI.Models;
namespace Assessment.WeatherAPI.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherData?> GetWeatherAsync(string searchCity);
    }
}

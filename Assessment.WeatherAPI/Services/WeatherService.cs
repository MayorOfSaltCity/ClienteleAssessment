
using Assessment.WeatherAPI.Models;
using Assessment.WeatherAPI.Repositories;

namespace Assessment.WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<WeatherData> GetWeatherAsync(string searchCity)
        {
            return await _weatherRepository.GetWeatherAsync(searchCity);
        }
    }
}

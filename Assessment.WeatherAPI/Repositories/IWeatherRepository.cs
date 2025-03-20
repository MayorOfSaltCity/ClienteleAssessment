using Assessment.WeatherAPI.Models;
using Newtonsoft.Json;
namespace Assessment.WeatherAPI.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherData> GetWeatherAsync(string searchCity);
    }

    public class WeatherRepository(HttpClient httpClient, IConfiguration configuration) : IWeatherRepository
    { 
        public async Task<WeatherData> GetWeatherAsync(string searchCity)
        {
            var openWeatherAPI = "http://api.openweathermap.org/data/2.5/";
            // get the api key from the configuration
            var apiKey = configuration["APIKey"];
            var response = await httpClient.GetAsync($"{openWeatherAPI}weather?q={searchCity}&appid={apiKey}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            // deserialize the json response to WeatherData object using newtonsoft json
            // create a json reader object
            var jsonReader = new JsonTextReader(new StringReader(content));
            var serializer = new JsonSerializer();
            var weatherData = serializer.Deserialize<WeatherData>(jsonReader);
            return weatherData!;
        }
    }
}

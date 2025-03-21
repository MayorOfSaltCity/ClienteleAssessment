using Assessment.WeatherAPI.Models;
using Newtonsoft.Json;
namespace Assessment.WeatherAPI.Repositories
{
    public class WeatherRepository(HttpClient httpClient, IConfiguration configuration) : IWeatherRepository
    { 
        public async Task<WeatherData?> GetWeatherAsync(string searchCity)
        {
            try
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
            catch (Exception e)
            {
                // log the exception
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

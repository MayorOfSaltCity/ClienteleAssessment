using Assessment.WeatherAPI.Models;
using Assessment.WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assessment.WeatherAPI.Pages
{
    public class WeatherModel(IWeatherService weatherService) : PageModel
    {
        [BindProperty]
        public WeatherData WeatherData { get; set; }
        public void OnGet()
        {
        }

        // On Post method take the city name as input and return the weather data
        public async Task OnPost(WeatherSearchModel weatherSearchModel)
        {
            // Call the GetWeatherAsync method from the weatherService and pass the city name
            var weatherData = await weatherService.GetWeatherAsync(weatherSearchModel.City);
            // Assign the result to the WeatherData property
            WeatherData = weatherData;
        }
    }

    public class WeatherSearchModel
    {
        public string City { get; set; }
    }
}

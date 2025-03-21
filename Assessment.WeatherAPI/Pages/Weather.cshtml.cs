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

        [BindProperty]
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        // On Post method take the city name as input and return the weather data
        public async Task OnPost(WeatherSearchModel weatherSearchModel)
        {
            try
            {
                // Call the GetWeatherAsync method from the weatherService and pass the city name
                var weatherData = await weatherService.GetWeatherAsync(weatherSearchModel.City);

                if (weatherData is null)
                {
                    ErrorMessage = "No data found for the city";
                    return;
                }

                // Assign the result to the WeatherData property
                WeatherData = weatherData;
            }
            catch (Exception e)
            {
                // If an exception is thrown, assign the exception message to the ErrorMessage property
                ErrorMessage = e.Message;
            }
        }
    }

    public class WeatherSearchModel
    {
        public string City { get; set; }
    }
}

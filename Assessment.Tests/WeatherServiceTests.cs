using Assessment.WeatherAPI.Models;
using Assessment.WeatherAPI.Repositories;
using Assessment.WeatherAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Tests
{
    
    public class WeatherServiceTests
    {
        [Fact]
        public async Task GetWeather_ReturnsWeatherData_ForValidCity()
        {
            // Arrange
            var weatherData = new WeatherData
            {
                City = "London",
                Temperature = 20,
                Humidity = 50,
                WindSpeed = 10
            };

            WeatherRepository.Setup(x => x.GetWeatherAsync("London")).ReturnsAsync(weatherData);

            // Act
            var result = await WeatherService.GetWeatherAsync("London");

            Assert.NotNull(result);
            Assert.Equal(weatherData.City, result.City);
            Assert.Equal(weatherData.Temperature, result.Temperature);
            Assert.Equal(weatherData.Humidity, result.Humidity);
            Assert.Equal(weatherData.WindSpeed, result.WindSpeed);

        }
        protected Mock<IWeatherRepository> WeatherRepository => weatherRepository ??= new Mock<IWeatherRepository>();
        protected IWeatherService WeatherService => weatherService ??= new WeatherService(WeatherRepository.Object);

        private Mock<IWeatherRepository> weatherRepository { get; set; }
        private IWeatherService weatherService { get; set; }

    }
}

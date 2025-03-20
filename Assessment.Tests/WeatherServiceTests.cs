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
            var mainWeatherData = new MainWeatherData
            {
                Temperature = 20,
                Humidity = 50,
                GroundLevelPressure = 10
            };
            // Arrange
            var weatherData = new WeatherData
            {
                MainWeatherData = mainWeatherData,
            };

            WeatherRepository.Setup(x => x.GetWeatherAsync("London")).ReturnsAsync(weatherData);

            // Act
            var result = await WeatherService.GetWeatherAsync("London");

            Assert.NotNull(result);
            Assert.Equal(20, result.MainWeatherData.Temperature);
            Assert.Equal(50, result.MainWeatherData.Humidity);
            Assert.Equal(10, result.MainWeatherData.GroundLevelPressure);


        }
        protected Mock<IWeatherRepository> WeatherRepository => weatherRepository ??= new Mock<IWeatherRepository>();
        protected IWeatherService WeatherService => weatherService ??= new WeatherService(WeatherRepository.Object);

        private Mock<IWeatherRepository> weatherRepository { get; set; }
        private IWeatherService weatherService { get; set; }

    }
}

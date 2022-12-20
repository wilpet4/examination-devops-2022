using API.Controllers;
using Moq;

namespace API.Tests
{
    public class Tests
    {
        private readonly Mock<IWeatherForecastController> _mockAPI = new Mock<IWeatherForecastController>();

        private static readonly string[] Summaries = new[]
        { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        IEnumerable<WeatherForecast> weatherForecasts;

        public Tests() 
        {
            weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _mockAPI.Setup(x => x.Get()).Returns(weatherForecasts);
        }

        [Fact]
        public void Get_Should_Return_NotNull()
        {
            // Arrange
            var controller = _mockAPI.Object;

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
        }
    }
}
using MyFoobar.Web.Interfaces;
using MyFoobar.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyFoobar.Tests.Services
{
    public class WeatherServiceTests
    {
        private readonly IWeatherService _weatherService;

        public WeatherServiceTests()
        {
            _weatherService = new WeatherService();
        }

        [Fact]
        public async Task Returns_Three_Day_Forecast_Given_Valid_Uri()
        {
            // Arrange
            var feedUrl = "https://weather-broker-cdn.api.bbci.co.uk/en/forecast/rss/3day/2641181";

            // Act
            List<string> result = await _weatherService.GetForecast(feedUrl);

            // Assert
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Throws_UriFormatException_Given_Malformed_Uri()
        {
            // Arrange
            var feedUrl = "invalid_url";

            // Act & Assert
            Assert.ThrowsAsync<UriFormatException>(async () => await _weatherService.GetForecast(feedUrl));
        }

        [Fact]
        public void Throws_WebException_Given_Unknown_Host_Uri()
        {
            // Arrange
            var feedUrl = "https://fail/test.rss";

            // Act & Assert
            Assert.ThrowsAsync<WebException>(async () => await _weatherService.GetForecast(feedUrl));
        }
    }
}


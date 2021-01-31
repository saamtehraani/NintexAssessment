using Microsoft.Extensions.Configuration;
using Moq;
using NintexAssessment.Models;
using NintexAssessment.Services;
using System;
using System.IO;
using System.Net.Http;
using Xunit;

namespace NintextAssessmentIntegrationTest
{
    public class FlightServiceIntegrationTest
    {
        private readonly IConfiguration _configuration;
        public FlightServiceIntegrationTest()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        [Fact]
        public void Test_The_End_Pint()
        {
            //Arrange
            FlightQueryModel fakeFlightQuery = FakeFlightQueryModel();
            var mockFactory = new Mock<IHttpClientFactory>();
            var client = new HttpClient()
            {
                BaseAddress = new Uri(_configuration.GetValue<string>("FlightURL")),
            };
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
            IHttpClientFactory factory = mockFactory.Object;

            //Act
            var flightService = new FlightService(mockFactory.Object);
            var result = flightService.SearchFlight(fakeFlightQuery);

            //Assert
            Assert.True(result.Result.Succeeded);
            Assert.NotEmpty(result.Result.Value);
        }

        private FlightQueryModel FakeFlightQueryModel()
        {
            return new FlightQueryModel
            {
                ArrivalAirportCode = "MEL",
                DepartureAirportCode = "LHR",
                DepartureDate = new DateTime(2020, 12, 1),
                ReturnDate = new DateTime(2020, 12, 30)
            };
        }
    }
}

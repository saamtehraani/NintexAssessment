using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NintexAssessment.Models;
using NintexAssessment.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NintexAssessmentXUnitTest
{
    public class FlightServiceUnitTest
    {
        [Fact]
        public void Return_Succeeded_True_When_Flight_Endpoint_Return_Result()
        {
            //Arrange
            List<FlightsModel> fakeFlights = FakeFlight();
            FlightQueryModel fakeFlightQuery = FakeFlightQueryModel();
            string response = JsonConvert.SerializeObject(fakeFlights);
            Mock<IHttpClientFactory> mockFactory = CreateMockFactory(response);

            //Act
            var flightService = new FlightService(mockFactory.Object);
            var result = flightService.SearchFlight(fakeFlightQuery);

            //Assert
            Assert.True(result.Result.Succeeded);
            Assert.NotNull(result);
        }        

        [Fact]
        public void Return_Succeeded_False_When_Flight_Endpoint_Has_Problem()
        {
            //Arrange
            FlightQueryModel fakeFlightQuery = FakeFlightQueryModel();
            string response = string.Empty;
            Mock<IHttpClientFactory> mockFactory = CreateMockFactory(response);

            //Act
            var flightService = new FlightService(mockFactory.Object);
            var result = flightService.SearchFlight(fakeFlightQuery);

            //Assert
            Assert.False(result.Result.Succeeded);
            Assert.NotNull(result);
        }

        private Mock<IHttpClientFactory> CreateMockFactory(string response)
        {
            Mock<IHttpClientFactory> mockFactory = new Mock<IHttpClientFactory>();
            Mock<HttpMessageHandler> mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            StringContent stringContent = new StringContent(response, Encoding.UTF8, "application/json");

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = stringContent,
                });

            HttpClient client = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            return mockFactory;
        }

        private FlightQueryModel FakeFlightQueryModel()
        {
            return new FlightQueryModel
            {
                ArrivalAirportCode = "MEL",
                DepartureAirportCode = "LHR",
                DepartureDate = new DateTime(2019, 12, 1),
                ReturnDate = new DateTime(2020, 1, 3)
            };
        }

        private List<FlightsModel> FakeFlight()
        {
            return new List<FlightsModel>
            {
                new FlightsModel()
                {
                    AirlineLogoAddress = string.Empty,
                    AirlineName = "Multi",
                    TotalAmount = 123
                },
                new FlightsModel()
                {
                    AirlineLogoAddress = string.Empty,
                    AirlineName = "Emirates Airline",
                    TotalAmount = 123
                }
            };
        }
    }
}

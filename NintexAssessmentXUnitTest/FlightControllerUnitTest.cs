using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NintexAssessment.Controllers;
using NintexAssessment.Infrastructure;
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
    public class FlightControllerUnitTest
    {
        private readonly Mock<IFlightService> _flightService;

        public FlightControllerUnitTest()
        {

            _flightService = new Mock<IFlightService>();
        }

        [Fact]
        public void Return_200_OK_Response_When_Flight_Service_Returns_Result()
        {
            //Arrange
            Result<List<FlightsModel>> fakeFlights = FakeFlight();
            FlightQueryModel fakeFlightQuery = FakeFlightQueryModel();
            string response = JsonConvert.SerializeObject(fakeFlights);
            _flightService.Setup(search => search.SearchFlight(fakeFlightQuery))
                .Returns(Task.FromResult(fakeFlights));

            //Act
            var flightController = new FlightController(_flightService.Object);
            var result = flightController.Post(fakeFlightQuery);
            var okResult = result.Result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Return_Bad_Request_Response_When_Flight_Service_Returns_Error()
        {
            //Arrange
            Result<List<FlightsModel>> fakeFlights = FakeFlightError();
            FlightQueryModel fakeFlightQuery = FakeFlightQueryModel();
            string response = JsonConvert.SerializeObject(fakeFlights);
            _flightService.Setup(search => search.SearchFlight(fakeFlightQuery))
                .Returns(Task.FromResult(fakeFlights));

            //Act
            var flightController = new FlightController(_flightService.Object);
            var result = flightController.Post(fakeFlightQuery);
            var badRequestResult = result.Result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
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

        private Result<List<FlightsModel>> FakeFlight()
        {
            var flights = new List<FlightsModel>
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

            return new Result<List<FlightsModel>>(flights);
        }

        private Result<List<FlightsModel>> FakeFlightError()
        {
            return new Result<List<FlightsModel>>("Error");
        }
    }
}

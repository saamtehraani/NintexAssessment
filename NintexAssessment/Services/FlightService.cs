using NintexAssessment.Infrastructure;
using NintexAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NintexAssessment.Services
{
    public class FlightService : IFlightService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FlightService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Result<List<FlightsModel>>> SearchFlight(FlightQueryModel model)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "flight");
            string payload = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            request.Content = content;

            var client = _clientFactory.CreateClient("FlightClient");

            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    IEnumerable<FlightsModel> flights = await JsonSerializer.DeserializeAsync
                            <IEnumerable<FlightsModel>>(responseStream);

                    return new Result<List<FlightsModel>>(flights.ToList());
                }
                else
                {
                    return new Result<List<FlightsModel>>();
                }
            }
            catch (Exception e)
            {
                return new Result<List<FlightsModel>>(e.Message);
            }
        }
    }
}

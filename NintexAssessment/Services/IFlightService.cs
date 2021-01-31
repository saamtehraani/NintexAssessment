using NintexAssessment.Infrastructure;
using NintexAssessment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NintexAssessment.Services
{
    public interface IFlightService
    {
        Task<Result<List<FlightsModel>>> SearchFlight(FlightQueryModel model);
    }
}

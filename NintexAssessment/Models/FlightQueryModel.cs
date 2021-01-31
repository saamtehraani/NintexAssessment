using System;

namespace NintexAssessment.Models
{
	public class FlightQueryModel
    {
		public string DepartureAirportCode { get; set; }
		public string ArrivalAirportCode { get; set; }
		public DateTime DepartureDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}

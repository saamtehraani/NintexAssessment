namespace NintexAssessment.Models
{
	public class FlightsModel
	{
		public string AirlineLogoAddress { get; set; }
		public string AirlineName { get; set; }
		public string InboundFlightsDuration { get; set; }
		public string ItineraryId { get; set; }
		public string OutboundFlightsDuration { get; set; }
		public int Stops { get; set; }
		public decimal TotalAmount { get; set; }
	}
}

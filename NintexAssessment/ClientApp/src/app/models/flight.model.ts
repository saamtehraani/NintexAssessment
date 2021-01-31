export interface FlightModel {
    airlineLogoAddress: string;
    airlineName: string;
    inboundFlightsDuration: string;
    itineraryId?: string;
    outboundFlightsDuration: string;
    stops: number;
    totalAmount: number;
}

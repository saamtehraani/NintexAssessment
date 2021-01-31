import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FlightModel } from '../../models/flight.model';

@Component({
    selector: 'app-search-flight',
    templateUrl: './search-flight.component.html'
})
export class SearchFlightComponent {
    @Output() flightFiltered: EventEmitter<FlightModel[]> = new EventEmitter<FlightModel[]>();
    @Input() flights: FlightModel[];
    @Input() originalFlights: FlightModel[];
    @Input() submited: boolean;

    filter($event: string): void {
        this.flights = this.originalFlights;
        this.flights = this.flights.filter(element => {
            return element.airlineName.toLowerCase().includes($event);
        });

        this.flightFiltered.emit(this.flights);
    }

    sortAZ(): void {
        this.flights = this.flights.sort((a, b) => a.airlineName.localeCompare(b.airlineName));
    }

    sortZA(): void {
        this.flights = this.flights.sort((a, b) => b.airlineName.localeCompare(a.airlineName));
    }

    sortPriceHL(): void {
        this.flights = this.flights.sort((a, b) => b.totalAmount - a.totalAmount);
    }

    sortPriceLH(): void {
        this.flights = this.flights.sort((a, b) => a.totalAmount - b.totalAmount);
    }

    sortStopHL(): void {
        this.flights = this.flights.sort((a, b) => b.stops - a.stops);
    }

    sortStopLH(): void {
        this.flights = this.flights.sort((a, b) => a.stops - b.stops);
    }
}

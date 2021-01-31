import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FlightModel } from '../../models/flight.model';

@Component({
    selector: 'app-flight',
    templateUrl: './flight.component.html'
})
export class FlightComponent {
    @Input() flights: FlightModel[];
    @Output() flightSelected: EventEmitter<FlightModel> = new EventEmitter<FlightModel>();

    page: number = 1;
    pageSize: number = 30;

    constructor(
    ) {
    }

    ngOnInit() {
    }

    flightChanged(flight: FlightModel): void {
        this.flightSelected.emit(flight);
    }
}

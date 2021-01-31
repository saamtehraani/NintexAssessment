import { TestBed } from '@angular/core/testing';
import { FlightService } from './flight.service';
import { HttpClientModule } from '@angular/common/http';

describe('FlightService', () => {
    let flightService: FlightService;
    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [HttpClientModule],
            providers: [FlightService]
        });
        flightService = TestBed.get(FlightService);
    });

    it('FlightService should be created', () => {
        const service: FlightService = TestBed.get(FlightService);
        expect(service).toBeTruthy();
    });
})

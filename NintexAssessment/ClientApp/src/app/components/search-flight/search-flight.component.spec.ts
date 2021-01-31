import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SearchFlightComponent } from './search-flight.component';
import { FlightModel } from '../../models/flight.model';

describe('SearchFlightComponent', () => {
    let component: SearchFlightComponent;
    let fixture: ComponentFixture<SearchFlightComponent>;
    let dummyFlight: FlightModel[] = [{
        airlineLogoAddress: '',
        airlineName: 'Jet Star',
        inboundFlightsDuration: '',
        itineraryId: '',
        outboundFlightsDuration: '',
        stops: 0,
        totalAmount: 45
    }, {
        airlineLogoAddress: '',
        airlineName: 'China',
        inboundFlightsDuration: '',
        itineraryId: '',
        outboundFlightsDuration: '',
        stops: 0,
        totalAmount: 46
    }];

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [SearchFlightComponent]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(SearchFlightComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });

    it(`sortAZ function test`, async(() => {
        fixture = TestBed.createComponent(SearchFlightComponent);
        component = fixture.debugElement.componentInstance;
        component.flights = dummyFlight;
        component.sortAZ();

        expect(component.flights[0].airlineName).toEqual('China');
    }));

    it(`sortPriceHL function test`, async(() => {
        fixture = TestBed.createComponent(SearchFlightComponent);
        component = fixture.debugElement.componentInstance;
        component.flights = dummyFlight;
        component.sortPriceHL();

        expect(component.flights[0].totalAmount).toEqual(46);
    }));
});

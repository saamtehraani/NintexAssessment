import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { Result } from '../../infrastructure/result';
import { FlightModel } from '../../models/flight.model';
import { FlightService } from '../../services/flight.service';
import { NgbdModalContent } from '../modal-content/modal-content.component';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    errors: string[];
    submitAttempt: boolean = false;
    submited: boolean = false;
    flightSearchFormGroup: FormGroup;
    flights: FlightModel[] = [];
    originalFlights: FlightModel[] = [];
    sort: string;

    constructor(
        private fb: FormBuilder,
        private flightService: FlightService,
        private modalService: NgbModal
        //private translate: TranslateService
    ) {
        //translate.setDefaultLang('en');
    }

    ngOnInit() {
        this.initializeForm();
    }

    initializeForm(): void {
        this.flightSearchFormGroup = this.fb.group(
            {
                arrivalAirportCode: new FormControl('', [
                    Validators.required,
                    Validators.maxLength(3),
                    Validators.minLength(3)
                ]),
                departureAirportCode: new FormControl('', [
                    Validators.required,
                    Validators.maxLength(3),
                    Validators.minLength(3)
                ]),
                departureDate: ['', Validators.required],
                returnDate: ['', Validators.required]
            }
        );
    }

    search(): void {
        console.log(this.flightSearchFormGroup);
        if (this.flightSearchFormGroup.valid) {
            this.submitAttempt = true;
            this.submited = true;
            const formValue = this.flightSearchFormGroup.value;

            this.flightService.search(formValue).subscribe(
                result => {
                    this.flights = result;
                    this.originalFlights = result;
                    this.submitAttempt = false;
                },
                error => {
                    this.submitAttempt = false;
                    this.errors = (<Result>error).errorList;
                });
        }
    }

    onFlightFiltered($event: FlightModel[]): void {
        this.flights = $event;
    }

    onFlightSelected($event: FlightModel): void {
        const modalRef = this.modalService.open(NgbdModalContent);
        modalRef.componentInstance.flight = $event;
    }

    get arrivalAirportCode() { return this.flightSearchFormGroup.get('arrivalAirportCode'); }

    get departureAirportCode() { return this.flightSearchFormGroup.get('departureAirportCode'); }
}

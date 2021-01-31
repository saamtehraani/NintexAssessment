import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FlightModel } from '../../models/flight.model';

@Component({
    selector: 'ngbd-modal-content',
    templateUrl: './modal-content.component.html'
})
export class NgbdModalContent {
    @Input() flight: FlightModel;

    constructor(public activeModal: NgbActiveModal) { }
}

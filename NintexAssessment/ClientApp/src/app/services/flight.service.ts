import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ServiceBase } from './serviceBase';
import { FlightQueryModel } from '../models/flight-query.model';
import { FlightModel } from '../models/flight.model';

@Injectable()
export class FlightService extends ServiceBase {
    private commonUrl: string = this.url + '/Flight/';
    constructor(
        private _http: HttpClient
    ) {
        super();
    }

    search(model: FlightQueryModel): Observable<FlightModel[]> {
        const completeUrl: string = this.commonUrl;
        return this._http
            .post<FlightModel[]>(completeUrl, model, {}).pipe(
                catchError(this.handleError));
    }
}

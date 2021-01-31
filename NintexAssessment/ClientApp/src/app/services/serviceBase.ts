import {throwError as observableThrowError,  Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

export class ServiceBase {
	url: string = 'api';
	public handleError(error: HttpErrorResponse) {
		return observableThrowError(error.error || 'Server error');
	}
}

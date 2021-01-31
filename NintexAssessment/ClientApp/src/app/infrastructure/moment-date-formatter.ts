import * as moment from 'moment';
import { NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

export class MomentDateFormatter extends NgbDateParserFormatter {
    readonly DT_FORMAT = 'DD-MM-YYYY';

    parse(value: string): NgbDateStruct {
        if (value) {
            const mdt = moment(value.trim(), this.DT_FORMAT);
            return { day: mdt.day(), month: mdt.months() + 1, year: mdt.year() };
        }
        return null;
    }
    format(date: NgbDateStruct): string {
        if (!date) {
            return '';
        }
        const mdt = moment([date.year, date.month - 1, date.day]);
        return mdt.isValid() ? mdt.format(this.DT_FORMAT) : '';
    }
}

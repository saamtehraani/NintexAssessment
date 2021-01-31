import { Component, Input } from "@angular/core";

@Component({
    selector: "error-message",
    templateUrl: "error-message.component.html"
})
export class ErrorMessageComponent {
    @Input() errors: string[];
    get showErrors() {
        return this.errors && this.errors.length > 0;
    };
}

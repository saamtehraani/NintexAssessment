import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
    isExpanded = false;

    constructor(
        private translate: TranslateService
    ) {
        translate.setDefaultLang('en');
    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    languageChange($event): void {
        switch ($event) {
            case 'en':
                this.translate.use('en');
                break;
            case 'ge':
                this.translate.use('ge');
                break;
        }
    }
}

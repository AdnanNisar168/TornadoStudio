import { Component, Inject, Input, LOCALE_ID, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';




import { Login } from '../models/login';
import { Router } from '@angular/router';
import { InventoryService } from '../inventory.service';
import { AppComponent } from '../app.component';
import { CommonService } from '../common.service';
import { Spinner } from '../models/spinner';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent  implements OnInit {
  @Input() show: boolean = false;
    spinner: Spinner;

    constructor(private commonService: CommonService) {
        //this.titleService.setTitle(this.pageTitle);
    }

    ngOnInit() {
        this.spinner = this.commonService.getSpinner();
    }
}






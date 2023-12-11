import { Component, ElementRef, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InventoryService } from '../inventory.service';
import { CommonService } from '../common.service';
import { User } from '../models/user';
import { forkJoin } from 'rxjs';



@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
})
export class UserComponent implements OnInit {

    public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

    private userKey: string;
    public user: User = new User();
    formGroup: FormGroup;
    public UpdatedByName: string;
    public UpdatedOn: string;


    // App Settings
    public IsEditAllowed: boolean;
    public IsCreateAllowed: boolean;
    //public loginInfo: LoginInfo;
    setAppSettings() {
        this.IsEditAllowed = true;
        this.IsCreateAllowed = true;
    }

    constructor(private route: ActivatedRoute, private router: Router, private fb: FormBuilder, private inventoryService: InventoryService, private commonService: CommonService, private el: ElementRef) {
        //super();

        this.userKey = this.route.snapshot.params["id"];

        this.formGroup = this.fb.group({
            CompanyID: [0],
            UserName: [''],
            Passwrod: [''],
            UserKey: [''],
        });
      
    }

    ngOnInit() {
        var self = this;
        //this.commonService.showSpinner('Loading...');

        // forkJoin([
        //     self.commonService.getLoginInfo().pipe(catchError(error => of(error))),
        // ])        
        // .subscribe(data => {
        //     self.loginInfo = data[0];
        //     self.loadData();
        // });



    }

    loadData() {
        var self = this;

        if (this.userKey) {
            self.inventoryService.getUser(self.userKey).subscribe(data => {
                self.user = data;

                self.formGroup.patchValue({
                    'UserKey': self.user.UserKey,
                    'UserName': self.user.UserName,
                    'Password': self.user.Password,
                    'CompanyID': self.user.CompanyID,
                });

                //self.commonService.hideSpinner();
            });
    } else {
            self.user = new User();
            self.user.UpdatedOn = new Date();
            // self.user.UpdatedByName = this.loginInfo.ImpersonateUser.UserName;
            self.user.UpdatedByName = 'Adnan Nsiar';
            // self.commonService.hideSpinner();
        }
    }

    onSubmit() {
        // this.commonService.showSpinner(null);

        this.inventoryService.saveUser(this.formGroup.value).subscribe(res => {
            // this.commonService.hideSpinner();

            let message = res.message;
            // ERROR MESSAGE
            if (res.http_code != 200) {
                res.broken_rules.forEach(x => {
                    message += '<br>' + x;
                });
            }

        //     Swal({
        //         title: 'Save Message',
        //         html: message,
        //         type: (res.http_code == 200 ? 'success' : 'error'),
        // }).then(result => {
        //         if (res.http_code == 200) {
        //             this.router.navigate(['/inventory/gender/list']);
        //         }
        //     });
        });
    }

    compareFn(c1: any, c2: any): boolean {
        return c1 && c2 ? c1 == c2 : false;
    }

}

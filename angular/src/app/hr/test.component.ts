import { Component, ElementRef, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { Observable, of } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';


import { InventoryService } from '../inventory.service';
import { User, UserList } from '../models/user';
import { TestService } from '../test.service';
import { Menus } from '../models/common';
import { Menu } from '../models/menu';
import { Test } from '../models/test';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
})
export class TestComponent  implements OnInit {
  public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

    public userKey: string;
    public test: Test = new Test();
    formGroup: FormGroup;
    public autoNumber: string;   
    public UpdatedByName: string;
    public UpdatedOn: string;
    public menuId: number = Menus.Department;
    public menu: Menu = new Menu();

    // App Settings
    private IsEditAllowed: boolean;
    private IsCreateAllowed: boolean;
    // public loginInfo: LoginInfo;
    setAppSettings() {
        this.IsEditAllowed = true;
        this.IsCreateAllowed = true;
    }
    
  //   numberMask = createNumberMask({
  //     allowDecimal: true,
  //     decimalLimit: 2,
  //     prefix: '',
  //     suffix: '' // This will put the dollar sign at the end, with a space.
  // });


  constructor(private route: ActivatedRoute, private fb: FormBuilder, private router: Router, @Inject(LOCALE_ID) private locale: string
  ,private inventoryService:InventoryService,private testService: TestService, private el: ElementRef) {
      //super();

      this.userKey = this.route.snapshot.params["id"] || 0;

      this.formGroup = this.fb.group({

        UserKey: [''],
        UserName: [''],
        Password: [''],
        CompanyID: ['']
          
      });

  }
  
  ngOnInit() {
    var self = this;
    forkJoin([
      // self.commonService.getLoginInfo().pipe(catchError(error => of(error))),
      ])
        this.loadData();

  }

  loadData() {
    var self = this;

    if (this.userKey) {
        self.testService.getTestUserCreate(self.userKey).subscribe(data => {
            self.test = data;

            self.formGroup.patchValue({
                'UserKey': self.test.UserKey,
                'UserName': self.test.UserName,
                'Password': self.test.Password,
                'CompanyID': self.test.CompanyID,
            });

           // this.UpdatedByName = self.department.UpdatedByName;
           // this.UpdatedOn = moment(self.department.UpdatedOn).format("DD-MMM-YYYY hh:mm A");
            // self.commonService.hideSpinner();
        });
    } else {
        self.test = new Test();
        self.test.UpdatedOn = new Date();
        self.test.UpdatedByName = 'ts.admin';//this.loginInfo.ImpersonateUser.UserName;


        // self.hrService.newDepartmentAutoNumber().pipe(catchError(error => of(error))).subscribe(data => {
        //     self.autoNumber = data;
        //     self.formGroup.patchValue({DepartmentCode: self.autoNumber});    
        // });


        // self.commonService.hideSpinner();
    }
}

onSubmit() {
  // this.commonService.showSpinner(null);

  this.testService.saveTestUser(this.formGroup.value).subscribe(res => {
      // this.commonService.hideSpinner();

      let message = res.message;
      if (res.http_code != 200) {
          res.broken_rules.forEach(x => {
              message += '<br>' + x;
          });
      }

      // Swal({
      //     title: 'Save Message',
      //     html: message,
      //     type: (res.http_code == 200 ? 'success' : 'error'),
      // }).then(result => {
      //     if (res.http_code == 200) {
      //         this.router.navigate(['/hr/department/list']);
      //     }
      // });
  });
}
}





// function createNumberMask(arg0: {
//   allowDecimal: boolean; decimalLimit: number; prefix: string; suffix: string; // This will put the dollar sign at the end, with a space.
// }) {
//   throw new Error('Function not implemented.');
// }


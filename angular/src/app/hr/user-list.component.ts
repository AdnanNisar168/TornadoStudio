import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { InventoryService } from '../inventory.service';
import { UserList } from '../models/user';

@Component({
  selector: 'app-User',
  templateUrl: './user-list.component.html',
})
export class UserListComponent  implements OnInit {
  formGroup: FormGroup;
    public menuId: number = 10069;
    public listData: UserList = new UserList();
    public currentPage: number = 1;
    public pageSize: number = 10;
    public sortColumn: string = 'GenderCode';
    public sortOrder: string = 'desc'
    public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

  // public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
  // numberMask = createNumberMask({
  //     allowDecimal: true,
  //     decimalLimit: 2,
  //     prefix: '',
  //     suffix: '' // This will put the dollar sign at the end, with a space.
  // });


  constructor(private fb: FormBuilder, private router: Router, @Inject(LOCALE_ID) private locale: string,private inventoryService:InventoryService) {
      //super();
      this.formGroup = this.fb.group({

          username: [''],
          password: [''],
          companyID: ['']
      });

  }
  
  ngOnInit() {
    var self = this;
        this.loadData();

  }

  loadData() {
    let self = this;
    let data = {
        ...this.formGroup.value,
        PageNumber: this.currentPage, PageLength: this.pageSize, SortColumn: self.sortColumn, SortOrder: self.sortOrder
    };

    //this.commonService.showSpinner("");

    this.inventoryService.getRoles(data).subscribe(data => {
        this.listData = data;

      //  self.commonService.hideSpinner();
    });

    
}

// onDelete(data) {
//   Swal({
//       title: 'Delete Confirmation',
//       text: "Are you sure, you want to delete record?",
//       showConfirmButton: true,
//       showCancelButton: true,
//       confirmButtonText: 'Yes',
//       cancelButtonText: 'No',
//   }).then(result => {
//       if (result.value) {
//           if (data && data.GenderID) {
//               this.inventoryService.deleteGenders(data.GenderID).subscribe(res => {
//                   this.loadData();
//               });
//           }
//       }
//   });
// }
onSortColumn(column: string) {
  if (this.sortColumn != column) {
      this.sortColumn = column;
      this.sortOrder = 'asc';
  } else if (this.sortOrder == 'asc') {
      this.sortOrder = 'desc';
  } else {
      this.sortOrder = 'asc';
  }
  this.loadData();
}
onSearchClick() {
  this.loadData();
}
}





function createNumberMask(arg0: {
  allowDecimal: boolean; decimalLimit: number; prefix: string; suffix: string; // This will put the dollar sign at the end, with a space.
}) {
  throw new Error('Function not implemented.');
}


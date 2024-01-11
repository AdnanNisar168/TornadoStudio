import { Component, Inject, LOCALE_ID } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CommonService } from '../common.service';
import { Router } from '@angular/router';
import { InventoryService } from '../inventory.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent {
  formGroup: FormGroup;
  isNewLogin: boolean = false;
  isLocalStorageloggedin: boolean = false;

  constructor(private inventoryService:InventoryService,private fb: FormBuilder,private commonService:CommonService, private router: Router, @Inject(LOCALE_ID) private locale: string,private inventory:InventoryService) {
    //super();
    this.formGroup = this.fb.group({

        username: [''],
        password: [''],
        RememberMe: [1]
    });

}
  ngOnInit(): void {
    var storedBoolean = localStorage.getItem('myBoolean');
    this.isLocalStorageloggedin = this.commonService.parseBoolean(storedBoolean);
    console.log('myBoolean from dashboard',storedBoolean)
    this.isLocalStorageloggedin = false;
    this.isNewLogin = this.commonService.parseBoolean(storedBoolean);
     
  }


  onWhatsAppClick(){

    this.inventoryService.getWhatsappApi().subscribe(res => {
          //this.loadData();
          if(res){
            res
          }
      });
  
  }
}

import { Component, OnInit, Inject, LOCALE_ID } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonService } from './common.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular';
  IsloggedIn: boolean = false;
  BrandName: string = 'TornadoStudio';

    constructor(private fb: FormBuilder,private commonService:CommonService, private router: Router, private route: ActivatedRoute, @Inject(LOCALE_ID) private locale: string) {

      }

      ngOnInit(){
         this.IsloggedIn = false;
         var storedBoolean = localStorage.getItem('myBoolean');
         // var booleanValue = JSON.parse(storedBoolean)
         var booleanValue = this.commonService.parseBoolean(storedBoolean);
         //this.IsloggedIn = booleanValue;
         this.IsloggedIn = booleanValue;
      }

      LoggOut(){
         localStorage.setItem('myBoolean', 'false');
        var logout = localStorage.getItem('myBoolean');
        this.IsloggedIn = this.commonService.parseBoolean(logout);
      }
}

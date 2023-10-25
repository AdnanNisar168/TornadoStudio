import { Component, OnInit, Inject, LOCALE_ID } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular';
  IsloggedIn: boolean = false;
  BrandName: string = 'TornadoStudio';

    constructor(private fb: FormBuilder, private router: Router, private route: ActivatedRoute, @Inject(LOCALE_ID) private locale: string) {

      }

      ngOnInit(){
         this.IsloggedIn = false;
      }
}

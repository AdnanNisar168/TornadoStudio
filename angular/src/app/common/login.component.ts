import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Login } from './model/login';
import { Router } from '@angular/router';
import { InventoryService } from '../inventory.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnInit {
  brandName: string = "Tornado Studio";
  public listData: Login = new Login();
  loginForm: FormGroup;

  // public mask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
  // numberMask = createNumberMask({
  //     allowDecimal: true,
  //     decimalLimit: 2,
  //     prefix: '',
  //     suffix: '' // This will put the dollar sign at the end, with a space.
  // });


  constructor(private fb: FormBuilder, private router: Router, @Inject(LOCALE_ID) private locale: string,private inventory:InventoryService) {
      //super();
      this.loginForm = this.fb.group({

          UserName: [''],
          Password: [''],
          RememberMe: [1]
      });

  }

  
    ngOnInit(): void {
      
       
    }
    // formGroup is group of input element in html tag
    // registerForm = new FormGroup({
    //   firstname: new FormControl(""),
    //   lastname: new FormControl(""),
    //   email: new FormControl(""),
    //   mobile: new FormControl(""),
    //   gender: new FormControl(""),
    //   pwd: new FormControl(""),
    //   rpwd: new FormControl(""),
      
    // })
    // loginForm = this.fb.group({
    //   firstname: ['', [Validators.required]],
    //   lastname: [''],
    //   email: [''],
    //   mobile: [''],
    //   gender: [''],
    //   pwd: [''],
    //   rpwd: [''],

    // });
    onSubmit(){
      this.inventory.saveLogin(this.loginForm.value).subscribe(res => {
      });
    }
  generateToken(payload: any, secretKey: string): string {
      const currentTime = Math.floor(Date.now() / 1000); // Get the current time in seconds
      const expirationTime = currentTime + 1800; // Set the token expiration time to 30 minutes (1800 seconds)
    
      const header = {
        alg: 'HS256',
        typ: 'JWT'
      };
    
      const encodedHeader = btoa(JSON.stringify(header));
      const encodedPayload = btoa(JSON.stringify({ ...payload, exp: expirationTime })); // Include the expiration time in the payload
      const signature = btoa(encodedHeader + '.' + encodedPayload + secretKey);
    
      return encodedHeader + '.' + encodedPayload + '.' + signature;
    }
    


  // public getToken() {
  //     const payload = { username: this.loginForm.value.UserName, role: 'Password' };
  //     const secretKey = this.generateSecretKey();
  //     const token = this.generateToken(payload, secretKey);
  //     this.authService.updateToken(token); // Update the token value in localStorage
  //     this.authService.isLoggedIn();
  //     console.log(token);
  //     // this.authService.isLoggedIn();
  //     //return;
  // }


  generateSecretKey(): string {
      const length = 32; // Length of the random string
      const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
      let result = '';

      for (let i = 0; i < length; i++) {
          const randomIndex = Math.floor(Math.random() * characters.length);
          result += characters.charAt(randomIndex);
      }
      // const randomString = randomBytes(length).toString('hex');
      return result;
  }

  onLogin(){

  }
  // onLogin() {

  //     const userName = this.loginForm.value.UserName;
  //     const password = this.loginForm.value.Password;

  //     if (!userName || !password) {
  //         Swal('Error', 'Both fields are required.', 'error');
  //         return;
  //     }
  //     this.commonService.showSpinner('Loading...');

  //     this.securityService.login(this.loginForm.value).subscribe(res => {
  //         this.commonService.hideSpinner();


  //         let message = res.message;
          
  //         if (res.http_code != 200) {
  //             res.broken_rules.forEach(x => {
  //                 message += '<br>' + x;
  //             });
  //         }

  //         Swal({
  //             // title: 'Save Message',
  //             html: message,
  //             type: (res.http_code == 200 ? 'success' : 'error'),
  //         }).then(result => {
  //             if (res.http_code == 200) {
  //                 this.getToken();
  //                 this.router.navigate(['/dashboard']);
  //             }
  //         });
  //     });
  // }


}





function createNumberMask(arg0: {
  allowDecimal: boolean; decimalLimit: number; prefix: string; suffix: string; // This will put the dollar sign at the end, with a space.
}) {
  throw new Error('Function not implemented.');
}


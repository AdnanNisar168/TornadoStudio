import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Login } from './models/login';
import { ResponseMessage } from './models/responseMessage';
import { UserList } from './models/user';
import { Spinner } from './models/spinner';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

    private spinner: Spinner = new Spinner();
  
  constructor(private http: HttpClient) { }
  
      parseBoolean(val: string | number | boolean | null) {
        let result = false;
        if (val == '' || val == null) {
            result = false;
        } else if (typeof val == 'string') {
            result = val == 'True' || val == 'true' || val == 'Yes' || val == 'yes' || val == '1';
        } else if (typeof val == 'number') {
            result = val > 0;
        } else if (typeof val == 'boolean') {
            result = val;
        }
        return result;
    }

    showSpinner(title: string) {
        if (!title) {
            this.spinner.title = "Please wait ...";
        } else {
            this.spinner.title = title;
        }

        this.spinner.isVisible = true;
    }
    hideSpinner() {
        this.spinner.isVisible = false;
    }
    getSpinner(): Spinner {
        return this.spinner;
    }
}

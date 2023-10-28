import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Login } from './models/login';
import { ResponseMessage } from './models/responseMessage';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  private apiUrl = 'http://localhost:56731/api'; // Replace with your ASP.NET MVC API URL
  constructor(private http: HttpClient) { }
   public getData(): Observable<any> {
    const url = `${this.apiUrl}/Login/login`; // Replace with your ASP.NET MVC endpoint URL

    return this.http.get<any>(url);
  }

  saveLogin(data: Login): Observable<Login> {
        var url = `${this.apiUrl}/Home/Login'`;

        return this.http.post<Login>(url, data)
            .pipe(
            tap(res => console.log('saved'))
            );
    }

    //role
    getroles(data): Observable<RoleList> {
      var url = '/QuickSecurity/Role/ListNG';

      return this.http.post<RoleList>(url, data)
          .pipe(
              tap(res => console.log('fetched Role list'))
          );
  }

  deleteRole(id): Observable<ResponseMessage> {
      var url = '/QuickSecurity/Role/Delete?key=' + id;
      return this.http.get<ResponseMessage>(url)
          .pipe(
              tap(res => console.log('deleted User Role'))
          );
  }

  getRole(data): Observable<Role> {
      var url = '/QuickSecurity/Role/CreateNG/' + data; 
      return this.http.get<Role>(url)
          .pipe(
              tap(res => console.log('fetched Role'))
          );
  }
  saveUser(data): Observable<ResponseMessage> {
      var url = '/QuickSecurity/User/SaveNG';

      return this.http.post<ResponseMessage>(url, data)
          .pipe(
              tap(res => console.log('saved'))
          );
  }

  saveRole(data): Observable<ResponseMessage> {
      var url = '/QuickSecurity/Role/SaveNG';

      return this.http.post<ResponseMessage>(url, data)
          .pipe(
              tap(res => console.log('saved'))
          );
  }

    //role

}

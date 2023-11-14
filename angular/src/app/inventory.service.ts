import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Login } from './models/login';
import { ResponseMessage } from './models/responseMessage';
import { UserList } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  private apiUrl = 'http://localhost:56731/api'; // Replace with your ASP.NET MVC API URL
  aspURL = "https://localhost:57685/api"; // qt asp.net
  aspURL2 = "https://localhost:57685/api/"; // qt asp.net
  baseServerUrl = "http://localhost:4200/api/"
  constructor(private http: HttpClient) { }
   public getData(): Observable<any> {
    const url = `${this.apiUrl}/Login/login`; // Replace with your ASP.NET MVC endpoint URL

    return this.http.get<any>(url);
  }

  saveLogin(data: Login): Observable<ResponseMessage> {
        //var url = `${this.apiUrl}/Home/Login`;
        //var url = `${this.aspURL}/Base/User/Index`;
        var url = this.aspURL +"User"

        return this.http.post<ResponseMessage>(url, data)
            .pipe(
            tap(res => console.log('saved'))
            );
    }
      getRoles(data: UserList): Observable<UserList> {
      //var url = '/QuickSecurity/Role/CreateNG/' + data; 
      var url = `${this.aspURL}/Base/User/DapperSPMethod`+ data; 
      return this.http.get<UserList>(url)
          .pipe(
              tap(res => console.log('fetched User'))
          );
  }

  getList(data: string): Observable<UserList> {
    //var url = '/QuickSecurity/Role/CreateNG/' + data; 
    var url = `${this.aspURL}/Base/User/List?UserKey=`+ data; 
    return this.http.get<UserList>(url)
        .pipe(
            tap(res => console.log('fetched User'))
        );
}

sndUserKey(){
  return this.http.post(this.aspURL2 + "/Base/User/List", null);
}

// getListng(data: UserList): Observable<UserList> {
//   const url = `${this.aspURL}/Base/User/List`;
//   const params = new HttpParams().set('param1', data.param1).set('param2', data.param2); // Replace param1 and param2 with actual parameter names
  
//   return this.http.get<UserList>(url, { params })
//       .pipe(
//           tap(res => console.log('fetched User'))
//       );
// }
// saveLogin(data: Login){
//     return  this.http.post(this.baseServerUrl + "Login" , null)
// }

    //role
//     getroles(data): Observable<RoleList> {
//       var url = '/QuickSecurity/Role/ListNG';

//       return this.http.post<RoleList>(url, data)
//           .pipe(
//               tap(res => console.log('fetched Role list'))
//           );
//   }

//   deleteRole(id): Observable<ResponseMessage> {
//       var url = '/QuickSecurity/Role/Delete?key=' + id;
//       return this.http.get<ResponseMessage>(url)
//           .pipe(
//               tap(res => console.log('deleted User Role'))
//           );
//   }

//   getRole(data): Observable<Role> {
//       var url = '/QuickSecurity/Role/CreateNG/' + data; 
//       return this.http.get<Role>(url)
//           .pipe(
//               tap(res => console.log('fetched Role'))
//           );
//   }
//   saveUser(data): Observable<ResponseMessage> {
//       var url = '/QuickSecurity/User/SaveNG';

//       return this.http.post<ResponseMessage>(url, data)
//           .pipe(
//               tap(res => console.log('saved'))
//           );
//   }

//   saveRole(data): Observable<ResponseMessage> {
//       var url = '/QuickSecurity/Role/SaveNG';

//       return this.http.post<ResponseMessage>(url, data)
//           .pipe(
//               tap(res => console.log('saved'))
//           );
//   }

    //role

}

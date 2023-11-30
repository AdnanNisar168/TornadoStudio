import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Login } from './models/login';
import { ResponseMessage } from './models/responseMessage';
import { User, UserList } from './models/user';
import { Test, TestList } from './models/test';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  // const headers = new HttpHeaders({
  //   'Content-Type': 'application/json',
  // });
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }
  

  // Test :
//   getTestUser(data: TestList): Observable<TestList> {
//     var url ='http://localhost:57685/test/list'+ data;

//     return this.http.post<TestList>(url, data)
//         .pipe(
//             tap(res => console.log('fetched Test List'))
//         );
// }
getTestUser(data: TestList): Observable<TestList> {
  var url ='http://localhost:57685/test/list/'+ data;

  return this.http.get<TestList>(url)
      .pipe(
          tap(res => console.log('fetched Test List'))
      );
}
getTestUserCreate(data: string): Observable<Test> {
  var url = 'http://localhost:57685/test/Index/' + data; 
  return this.http.get<Test>(url)
      .pipe(
          tap(res => console.log('fetched Test User'))
      );
}
saveTestUser(data: Test): Observable<ResponseMessage> {
  var url = 'http://localhost:57685/test/Save';

  return this.http.post<ResponseMessage>(url, data)
      .pipe(
          tap(res => console.log('saved'))
      );
}

// saveRates(data): Observable<ResponseMessage> {
//   var url = '/Inventory/Item/UpdateItemVariationRates';

//   return this.http.post<ResponseMessage>(url, data, this.httpOptions)
//       .pipe(
//       tap(_ => console.log('saved')),
//       catchError(this.handleError<any>('save rates'))
//       );
// }
getListData(data: TestList): Observable<TestList> {
  const url = 'http://localhost:57685/test/List'+ data; // Replace with your API URL

  // Set request headers if needed
  const headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  // Define the request body with the parameters
  // const requestBody = {
  //   SortColumn: 'yourSortColumn',
  //   SortOrder: 'yourSortOrder',
  //   PageNumber: 1, // Replace with your desired values
  //   PageLength: 10, // Replace with your desired values
  //   number: 'yourNumber',
  //   party: 'yourParty',
  //   remarks: 'yourRemarks',
  //   headName: 'yourHeadName',
  //   detailHeadName: 'yourDetailHeadName',
  //   startDate: 'yourStartDate',
  //   endDate: 'yourEndDate',
  //   amountStart: 'yourAmountStart',
  //   amountEnd: 'yourAmountEnd',
  //   recordStatusID: 1, // Replace with your desired values
  // };

  // return this.http.post<TestList>(url, data, { headers });
  return this.http.get<TestList>(url);
}
  // Test :



  // getList(data: string): Observable<UserList> {
  //   //var url = '/QuickSecurity/Role/CreateNG/' + data; 
  //   let key = 'DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC'
  //   var url ='http://localhost:57685/user/List?UserKey='+key;
  //   //var url ='/user/List?UserKey=DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC'
  //   return this.http.get<UserList>(url)
  //       .pipe(
  //           tap(res => console.log('fetched User'))
  // );
  //}
  getList(data: UserList): Observable<UserList> {
    
    
    var url ='http://localhost:57685/user/List';
    //var url ='/user/List?UserKey=DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC'
    return this.http.post<UserList>(url,data)
        .pipe(
            tap(res => console.log('fetched User'))
  );}
getUser(data: string): Observable<User> {
  //var url = '/Inventory/Gender/Index/' + data; 
  var url ='http://localhost:57685/user/Index'+ data;
  return this.http.get<User>(url)
      .pipe(
          tap(res => console.log('fetched Gender'))
      );
}
saveUser(data: User): Observable<ResponseMessage> {
  //var url = '/Inventory/Gender/Save';
  var url ='http://localhost:57685/user/Save';

  return this.http.post<ResponseMessage>(url, data)
      .pipe(
          tap(res => console.log('User saved'))
      );
}
deleteUser(id: string): Observable<ResponseMessage> {
  var url = 'http://localhost:57685/user/Delete?id=' + id;

  return this.http.post<ResponseMessage>(url, id)
      .pipe(
          tap(res => console.log('deleted Gender'))
      );
}
// sndUserKey(){
//   return this.http.post(this.aspURL2 + "/Base/User/List", null);
// }

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

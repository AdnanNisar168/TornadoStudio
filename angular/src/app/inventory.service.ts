import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Login } from './models/login';

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
}

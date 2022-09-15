import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Login } from '../Models/Login';

@Injectable({
  providedIn: 'root'
})

export class LoginService {

  private ApiUrl = 'https://localhost:7010';
  private ApiUrl2 = 'http://localhost:5010';

  constructor(private http: HttpClient) { }

  public getLogin(): Observable<Login>
  {
    return this.http.get<Login>(this.ApiUrl + "/Login" || this.ApiUrl2 + "/Login");
  }

}

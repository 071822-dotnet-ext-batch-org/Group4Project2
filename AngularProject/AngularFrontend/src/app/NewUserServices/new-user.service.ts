import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'
import { CustomerRegisterDto } from '../Models/CustomerRegisterDto';


@Injectable({ providedIn: 'root'})
export class NewUserService {
  
  private ApiUrl = 'https://localhost:7010';
  
  constructor(private http: HttpClient) { }
  
  public register(TempRegisterDto: CustomerRegisterDto): Observable<CustomerRegisterDto>
  {
    return this.http.post<CustomerRegisterDto>(this.ApiUrl + "/RegisterAccountAsync",TempRegisterDto);
  }
  
  
  
  // postNewUser(CustomerRegisterDto:CustomerRegisterDto): Observable<any>
  // {
  //   const headers = { 'content-type': 'application/json'}  
  //   const body=JSON.stringify(CustomerRegisterDto);
  //   console.log(body)
  //   return this.http.post(this.ApiUrl + "/RegisterAccountAsync", body, {'headers':headers} );
  // }


}

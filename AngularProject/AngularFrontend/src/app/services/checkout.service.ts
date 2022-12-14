import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductInfoDto } from '../Models/ProductInfoDto';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CheckoutRequestService {

  private ApiUrl = "https:localhost:7010";

  //http object injected with apiUrl dependency
  constructor(private http: HttpClient) { }


}

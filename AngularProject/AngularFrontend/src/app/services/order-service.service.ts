import { Injectable } from '@angular/core';
import { Orders } from '../Models/Orders';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderServiceService {


  constructor(private http: HttpClient) { }
    private rootUrl = 'https://localhost:7010';

  public getOrders(): Observable<Orders[]>{
    return this.http.get<Orders[]>(this.rootUrl + '/ViewOrderAsync');
  }

  public getOrderTracker(orderTracker: string): Observable<Orders> {
    return this.http.get<Orders>(this.rootUrl + '/ViewOrderAsync');
  }

}

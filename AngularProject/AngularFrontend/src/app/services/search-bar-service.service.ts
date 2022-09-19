import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class SearchBarServiceService {

  private ApiUrl = 'http://localhost:5010';
  constructor(private http: HttpClient) { }

  getTitle(): Observable<any>{
    return this.http.get(this.ApiUrl + "/title");
  }
}

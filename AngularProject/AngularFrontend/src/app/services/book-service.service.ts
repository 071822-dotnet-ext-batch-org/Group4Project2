import { Injectable } from '@angular/core';
import { AllBooks } from '../Models/AllBooks';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookServiceService {

  constructor(private http: HttpClient) { }
    private rootUrl = 'https://localhost:7010';

  public getAllBooks(): Observable<AllBooks[]>{
    return this.http.get<AllBooks[]>(this.rootUrl + '/DisplayAll');
  }
}

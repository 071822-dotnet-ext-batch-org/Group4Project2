import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Profile } from '../Models/Profile';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ProfileService {

  constructor(private http: HttpClient) { }

  private rootUrl = 'https://localhost:7010';
  private rootUrl2 = 'http://localhost:5010';


  public getProfile(): Observable<Profile []>
  {
    return this.http.get<Profile []>(this.rootUrl + "/Profile" || this.rootUrl2 + "/Profile");
  }

}

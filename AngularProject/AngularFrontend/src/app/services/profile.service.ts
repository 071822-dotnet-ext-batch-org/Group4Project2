import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Profile } from '../Models/Profile';

@Injectable({
  providedIn: 'root'
})

export class ProfileService {

  private ApiUrl = 'https://localhost:7010';
  private ApiUrl2 = 'http://localhost:5010';

  constructor(private http: HttpClient) { }

  public getLogin(): Observable<Profile>
  {
    return this.http.get<Profile>(this.ApiUrl + "/Profile" || this.ApiUrl2 + "/Profile");
  }

}

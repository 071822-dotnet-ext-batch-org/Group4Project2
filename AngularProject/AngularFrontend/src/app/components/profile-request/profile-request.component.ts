import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductInfoDto } from '../../Models/ProductInfoDto';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-profile-request',
  templateUrl: './profile-request.component.html',
  styleUrls: ['./profile-request.component.css']
})
export class ProfileRequestComponent implements OnInit {

  /// Need to Change depending on deployment method ///
  private rootUrl = 'https://localhost:7010';
  private rootUrl2 = 'http://localhost:5010';
  newPerson: any;
  constructor(private PS: ProfileService) { }

  ngOnInit(): void {
  }

  displayPerson()
  {
    this.PS.getProfile().subscribe(data =>
      {
        this.newPerson = data;
        ///////
      })
  }

  //public getProductInfoDtos(): Observable<ProductInfoDto>
  //{
  //  return this.http.get<this.getProductInfoDtos[]>(this.rootUrl || this.rootUrl2)
  //}

  displaynewPerson()
  {
    this.PS.getProfile().subscribe(data =>
      {
        this.newPerson = data;
        ///////
      })
  }

}

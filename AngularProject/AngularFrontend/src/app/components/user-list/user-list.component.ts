import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/services/profile.service';
import { Profile } from 'src/app/Models/Profile';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  profile?: Profile[] = [];

  constructor(private PService: ProfileService) { }

  ngOnInit(): void {
    this.getProfile()
  }

  getProfile(): void {
    this.PService.getProfile()
      .subscribe( profile => this.profile = profile);
  }

}

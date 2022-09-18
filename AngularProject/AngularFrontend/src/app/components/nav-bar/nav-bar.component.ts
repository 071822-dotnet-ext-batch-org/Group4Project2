import { Component, OnInit} from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { ProductSearchComponent } from 'src/app/product-search/product-search.component';
<<<<<<< HEAD

=======
>>>>>>> e39a28daf09db0c55117901cf6848d951252da8c

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})

export class NavBarComponent implements OnInit {


  constructor(public auth:AuthService) {}


  ngOnInit(): void {
  }
}

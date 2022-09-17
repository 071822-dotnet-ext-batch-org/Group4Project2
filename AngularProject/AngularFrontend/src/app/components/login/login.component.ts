import { Component, OnInit } from '@angular/core';

// Import the AuthService type from the SDK
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-login',
  template: '<button (click)="login()">Login</button>',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnInit{
  // Inject the authentication service into your component through the constructor
  constructor(public auth: AuthService) {}

  ngOnInit(): void {

  }
  login(): void{
    this.auth.loginWithRedirect()

  }
}

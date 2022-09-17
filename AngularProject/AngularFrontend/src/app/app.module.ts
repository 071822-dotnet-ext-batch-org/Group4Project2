import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from '@auth0/auth0-angular';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductAlertsComponent } from './product-alerts/product-alerts.component';
import { RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from '@auth0/auth0-angular';
import { ProductSearchComponent } from './product-search/product-search.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { UserComponent } from './components/user/user.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { AuthButtonComponent } from './components/auth-button/auth-button.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ProductListComponent,
    ProductAlertsComponent,
    ProductDetailsComponent,
    CartComponent,
    LoginComponent,
    LogoutComponent,
    RegisterComponent,
    AuthButtonComponent,
    UserComponent,
    UserListComponent,
    ProductSearchComponent,
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ProductListComponent },
      { path: 'products/:productisbn', component: ProductDetailsComponent },
      { path: 'cart', component: CartComponent },
      { path: 'components/auth-button', component: AuthButtonComponent},
      { path: 'components/nav-bar', component: NavBarComponent}
    ]),
    AuthModule.forRoot({
     domain: 'http://dev-9hex7qt2.us.auth0.com',
     clientId: '5GSDTOk5VV9d5ZgiYetm1NmP0VA6EXr2',
     audience: 'https://dev-9hex7qt2.us.auth0.com/api/v2/',
     httpInterceptor: {
        allowedList: ['https://localhost:7010/Profile'],
     }
    }),
  ],


  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    }
  ],

  bootstrap: [AppComponent],

  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})

export class AppModule { }

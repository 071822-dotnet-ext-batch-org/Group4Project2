import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductAlertsComponent } from './product-alerts/product-alerts.component';
import { RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import {AuthModule } from '@auth0/auth0-angular'
import { HttpClientModule } from '@angular/common/http';
import { AuthbuttonComponent } from './components/auth-button/auth-button.component';
import { UserComponent } from './components/user/user.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';
@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductListComponent,
    ProductAlertsComponent,
    ProductDetailsComponent,
    CartComponent,
    AuthbuttonComponent,
    UserComponent,
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ProductListComponent },
      { path: 'products/:productisbn', component: ProductDetailsComponent },
      { path: 'cart', component: CartComponent },
    ]),
    AuthModule.forRoot({
     domain: 'http://dev-9hex7qt2.us.auth0.com',
     clientId: '5GSDTOk5VV9d5ZgiYetm1NmP0VA6EXr2',
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
  bootstrap: [AppComponent]
})

export class AppModule { }

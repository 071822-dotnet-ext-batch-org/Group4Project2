import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from '@auth0/auth0-angular';
import { RegisterComponent } from './components/register/register.component';
import { CartComponent } from './cart/cart.component';
import { AuthButtonComponent } from './components/auth-button/auth-button.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';

const routes: Routes = [
  {
    path:'', component:ProductListComponent
  },
  {
    path:'product/:productId', component:ProductDetailsComponent
  },
  { path: 'register', component: RegisterComponent},
  { path: 'search/:searchTerm', component: ProductListComponent},
  {
    path:'profile', component:ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'orders', component: OrdersListComponent
  },
  {
    path:'components/user-list', component:UserListComponent,
    canActivate: [AuthGuard]
  },
      //////////uncomment////////
 // {// Added for cart to payment
 //   path: 'cart', component: CartComponent
 // },


  {
    path: 'components/auth-button', component:AuthButtonComponent
  },

  {
    path: 'allbooks', component: BookListComponent,
  }


  //{
  //  path:'filter', component:FilterComponent
  //}





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

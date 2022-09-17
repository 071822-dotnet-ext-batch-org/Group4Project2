import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { UserComponent } from './components/user/user.component';
import { AuthGuard } from '@auth0/auth0-angular';
import { RegisterComponent } from './components/register/register.component';
import { CartComponent } from './cart/cart.component';


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
    path:'components/user', component:UserComponent, canActivate: [AuthGuard]
  },
      //////////uncomment////////
 // {// Added for cart to payment
 //   path: 'cart', component: CartComponent
 // },

  //{
 //   path: 'components/auth-button', component:AuthButtonComponent
 // }

  //{ path: 'register', component: RegisterComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

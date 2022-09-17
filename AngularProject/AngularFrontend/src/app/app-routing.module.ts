import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from '@auth0/auth0-angular';
//import { RegisterComponent } from './register/register.component';
import { FilterComponent } from './filter/filter.component';
import { AuthButtonComponent } from './components/auth-button/auth-button.component';

const routes: Routes = [
  {
    path:'', component:ProductListComponent
  },
  {
    path:'product/:productId', component:ProductDetailsComponent
  },

  {
    path:'profile', component:ProfileComponent
  },

  {
    path:'components/user-list', component:UserListComponent
  },

  {
    path: 'components/auth-button', component:AuthButtonComponent
  },

  {
    path:'filter', component:FilterComponent
  }


  //{ path: 'register', component: RegisterComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

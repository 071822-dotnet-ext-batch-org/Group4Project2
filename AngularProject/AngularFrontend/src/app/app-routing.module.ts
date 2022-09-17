import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { UserComponent } from './components/user/user.component';
import { AuthGuard } from '@auth0/auth0-angular';
//import { RegisterComponent } from './register/register.component';
import { FilterComponent } from './filter/filter.component';
import { ProductSearchComponent } from './product-search/product-search.component';

const routes: Routes = [
  {
    path:'', component:ProductListComponent
  },
  {
    path:'products/:productId', component:ProductDetailsComponent
  },
<<<<<<< HEAD
  { path: 'register', component: RegisterComponent},
  { path: 'product-search', component: ProductSearchComponent}
=======

  {
    path:'components/user', component:UserComponent, canActivate: [AuthGuard]
  }

  //{ path: 'register', component: RegisterComponent}

>>>>>>> f424bb1f79124b7fe58cd7bcb5aeaa44d933287b
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

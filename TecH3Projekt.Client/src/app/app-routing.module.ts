import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { CRUDProductComponent } from './Components/Admin/crudproduct/crudproduct.component';//
import { CRUDTypeComponent } from './Components/Admin/crudtype/crudtype.component';//
import { CRUDUsersComponent } from './Components/Admin/crudusers/crudusers.component';

import { ReadOrdersComponent } from './Components/Admin/read-orders/read-orders.component';
import { LoginFormComponent } from './Components/login-form/login-form.component';//
import { CategoryComponent } from './Components/Pages/category/category.component';//
import { HomeComponent } from './Components/Pages/home/home.component';//
import { OpretKundeComponent } from './Components/Pages/opret-kunde/opret-kunde.component';//
import { ProductComponent } from './Components/Pages/product/product.component';
import { SearchComponent } from './Components/Pages/search/search.component';//
import { ShoppingBasketComponent } from './Components/Pages/shopping-basket/shopping-basket.component';//
import { UsersComponent } from './Components/users/users.component';//

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch:'full'}, //Start at Home page.
  
  { path: 'users', component:UsersComponent}, //USE for testing

  //Detail route
  {path: 'Update-type/:id', component:CategoryDetailComponent},
  {path: 'Update-product/:id', component:ProductDetailComponent},

  //CATEGORIES TEST ROUTES.

  { path: 'category/:typeID', component:CategoryComponent},


  //PAGE Routes.
  { path: 'home', component:HomeComponent},
  //{ path: 'category', component:CategoryComponent},// add :id when complete/ or type??
  { path: 'search', component:SearchComponent},
  { path: 'login', component:LoginFormComponent},
  { path: 'basket', component:ShoppingBasketComponent},
  
  //EXTRA Routes.
  {path: 'opretKunde', component:OpretKundeComponent},//
  {path: 'product/:id', component:ProductComponent},//

  //ADMIN Routes.
  {path: 'CRUD-types', component:CRUDTypeComponent},
  {path: 'CRUD-products', component:CRUDProductComponent},
  {path: 'CRUD-users', component:CRUDUsersComponent},
  {path: 'orderOverview', component:ReadOrdersComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

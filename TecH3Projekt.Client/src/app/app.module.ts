import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';//
import {HttpClientModule} from '@angular/common/http';//

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UsersComponent } from './Components/users/users.component';
import { NavBarComponent } from './Components/Shared/nav-bar/nav-bar.component';
import { FooterComponent } from './Components/Shared/footer/footer.component';
import { HeaderComponent } from './Components/Shared/header/header.component';
import { HomeComponent } from './Components/Pages/home/home.component';
import { CategoryComponent } from './Components/Pages/category/category.component';
import { LoginFormComponent } from './Components/login-form/login-form.component';
import { OpretKundeComponent } from './Components/Pages/opret-kunde/opret-kunde.component';
import { ShoppingBasketComponent } from './Components/Pages/shopping-basket/shopping-basket.component';
import { ProductComponent } from './Components/Pages/product/product.component';
import { CRUDTypeComponent } from './Components/Admin/crudtype/crudtype.component';
import { CRUDProductComponent } from './Components/Admin/crudproduct/crudproduct.component';
import { CRUDUsersComponent } from './Components/Admin/crudusers/crudusers.component';
import { ReadOrdersComponent } from './Components/Admin/read-orders/read-orders.component';
import { SearchComponent } from './Components/Pages/search/search.component';

import { CategoryDetailComponent } from './category-detail/category-detail.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { CartComponent } from './Components/Pages/cart/cart.component';
import { CartItemComponent } from './Components/Pages/cart-item/cart-item.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    NavBarComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    CategoryComponent,
    LoginFormComponent,
    OpretKundeComponent,
    ShoppingBasketComponent,
    ProductComponent,
    CRUDTypeComponent,
    CRUDProductComponent,
    CRUDUsersComponent,
    ReadOrdersComponent,
    SearchComponent,
    CategoryDetailComponent,
    ProductDetailComponent,
    CartComponent,
    CartItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

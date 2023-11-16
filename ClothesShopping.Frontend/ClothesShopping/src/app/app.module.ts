import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material/angular-material.module';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdministrationComponent } from './components/administration/administration.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { ProductsComponent } from './components/products/products.component';
import { UsersComponent } from './components/users/users.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { BrandsComponent } from './components/brands/brands.component';
import { ColorsComponent } from './components/colors/colors.component';
import { OrdersAdminComponent } from './components/orders-admin/orders-admin.component';
import { ProductsAdminComponent } from './components/products-admin/products-admin.component';
import { OrdersComponent } from './components/orders/orders.component';
import { LoginComponent } from './components/login/login.component';
import { FormUserComponent } from './components/form-user/form-user.component';
import { FormProductComponent } from './components/form-product/form-product.component';
import { PromotionsComponent } from './components/promotions/promotions.component';
import { FormPromotionComponent } from './components/form-promotion/form-promotion.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { OrderDetailComponent } from './components/order-detail/order-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    AdministrationComponent,
    ShoppingCartComponent,
    ProductsComponent,
    UsersComponent,
    CategoriesComponent,
    BrandsComponent,
    ColorsComponent,
    OrdersAdminComponent,
    ProductsAdminComponent,
    OrdersComponent,
    LoginComponent,
    FormUserComponent,
    FormProductComponent,
    PromotionsComponent,
    FormPromotionComponent,
    ProductDetailComponent,
    RegisterUserComponent,
    OrderDetailComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

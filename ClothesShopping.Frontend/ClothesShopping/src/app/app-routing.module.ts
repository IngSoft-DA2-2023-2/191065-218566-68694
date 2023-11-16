import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdministrationComponent } from './components/administration/administration.component';
import { BrandsComponent } from './components/brands/brands.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { ColorsComponent } from './components/colors/colors.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrdersAdminComponent } from './components/orders-admin/orders-admin.component';
import { ProductsComponent } from './components/products/products.component';
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { UsersComponent } from './components/users/users.component';
import { LoginComponent } from './components/login/login.component';
import { ProductsAdminComponent } from './components/products-admin/products-admin.component';
import { PromotionsComponent } from './components/promotions/promotions.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { RoleGuard } from './role-guard';

const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  {
    path: 'administration', component: AdministrationComponent,
    canActivate: [RoleGuard],
    data: { expectedRole: 'Administrator' },
  },
  {
    path: 'brands', component: BrandsComponent,
  },
  { path: 'categories', component: CategoriesComponent },
  { path: 'colors', component: ColorsComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'orders-admin', component: OrdersAdminComponent },
  { path: 'products', component: ProductsComponent },
  {
    path: 'products-admin', component: ProductsAdminComponent,
    canActivate: [RoleGuard],
    data: { expectedRole: 'Administrator' },
  },
  { path: 'shopping-cart', component: ShoppingCartComponent },
  {
    path: 'users', component: UsersComponent,
    canActivate: [RoleGuard],
    data: { expectedRole: 'Administrator' },
  },
  { path: 'login', component: LoginComponent },
  {
    path: 'promotions', component: PromotionsComponent,
    canActivate: [RoleGuard],
    data: { expectedRole: 'Administrator' },
  },
  { path: 'register', component: RegisterUserComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }

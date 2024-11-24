import { Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { AuthGuard } from '../guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { AdminGuard } from '../guards/admin.guard';
import { UsersComponent } from './users/users.component';
import { UsersAddComponent } from './users/users-add/users-add.component';
import { MasterLayoutComponent } from './master-layout/master-layout.component';
import { BlankLayoutComponent } from './blank-layout/blank-layout.component';

export const routes: Routes = [
  {
    path: '',
    component: MasterLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '',   redirectTo: 'products', pathMatch: 'full' },
      { path: 'users', component: UsersComponent, canActivate: [AdminGuard]},
      { path: "users/add", component: UsersAddComponent, canActivate: [AdminGuard] },
      { path: "products", component: ProductComponent },
      { path: "products/add", component: ProductAddComponent, canActivate: [AdminGuard] },
      { path: "products/edit/:id", component: ProductEditComponent, canActivate: [AdminGuard]}
    ]
  },
  {
    path: '',
    component: BlankLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent},
      { path: "**", component: PageNotFoundComponent }
    ]
  }
];

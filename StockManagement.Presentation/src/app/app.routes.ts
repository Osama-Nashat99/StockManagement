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
import { CategoryComponent } from './category/category.component';
import { CategoryAddComponent } from './category/category-add/category-add.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { StoreComponent } from './store/store.component';
import { StoreAddComponent } from './store/store-add/store-add.component';
import { StoreEditComponent } from './store/store-edit/store-edit.component';

export const routes: Routes = [
  {
    path: '',
    component: MasterLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '',   redirectTo: 'products', pathMatch: 'full' },
      { path: 'users', component: UsersComponent, canActivate: [AdminGuard]},
      { path: "users/add", component: UsersAddComponent, canActivate: [AdminGuard] },
      { path: 'categories', component: CategoryComponent},
      { path: 'categories/add', component: CategoryAddComponent, canActivate: [AdminGuard]},
      { path: "products", component: ProductComponent },
      { path: "products/add", component: ProductAddComponent, canActivate: [AdminGuard] },
      { path: "products/edit/:id", component: ProductEditComponent, canActivate: [AdminGuard]},
      { path: "stores", component: StoreComponent },
      { path: "stores/add", component: StoreAddComponent, canActivate: [AdminGuard] },
      { path: "stores/edit/:id", component: StoreEditComponent, canActivate: [AdminGuard] },
      { path: "password/reset", component: ResetPasswordComponent }
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

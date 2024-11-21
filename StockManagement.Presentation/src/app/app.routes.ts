import { Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';
import { AuthGuard } from '../guards/auth.guard';
import { LoginComponent } from './login/login.component';
import { AdminGuard } from '../guards/admin.guard';

export const routes: Routes = [
    { path: '',   redirectTo: 'products', pathMatch: 'full' },
    { path: 'login', component: LoginComponent},
    { path: "products", component: ProductComponent, canActivate: [AuthGuard] },
    { path: "products/add", component: ProductAddComponent, canActivate: [AuthGuard, AdminGuard] },
    { path: "products/edit/:id", component: ProductEditComponent, canActivate: [AuthGuard, AdminGuard]},
    { path: "**", component: PageNotFoundComponent }
];

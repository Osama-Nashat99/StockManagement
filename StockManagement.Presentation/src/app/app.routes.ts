import { Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ProductAddComponent } from './product/product-add/product-add.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductEditComponent } from './product/product-edit/product-edit.component';

export const routes: Routes = [
    { path: '',   redirectTo: 'products', pathMatch: 'full' },
    { path: "products", component: ProductComponent },
    { path: "products/add", component: ProductAddComponent },
    { path: "products/edit/:id", component: ProductEditComponent},
    { path: "**", component: PageNotFoundComponent }
];

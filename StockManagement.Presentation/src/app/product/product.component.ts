import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/Product.model';
import { NgFor, NgIf } from '@angular/common';
import { category } from '../../enums/category.enum';
import { finalize } from 'rxjs';
import { ProductService } from '../services/product.service';
import { RouterLink } from '@angular/router';
import { MatPaginatorModule, PageEvent,  } from '@angular/material/paginator';
import { ExportToExcelComponent } from '../export-to-excel/export-to-excel.component';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from '../header/header.component';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [NgFor, NgIf, RouterLink, FormsModule, MatPaginatorModule, ExportToExcelComponent, HeaderComponent],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  productsList: Product[] = [];
  loading: boolean = false;
  totalProducts: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  pageSizeOptions: number[] = [5, 10, 25, 50];
  showFirstLastButtons = true;
  nameFilter: string = '';
  descriptionFilter: string = '';

  constructor(private productService: ProductService, private authService: AuthService){}

  ngOnInit(): void {
    this.loadProducts()
  }

  loadProducts() {
    this.loading = true;

    this.productService.fetchAll(this.currentPage, this.pageSize, this.nameFilter, this.descriptionFilter)
      .pipe(
        finalize(() => {
          this.loading = false;
        })
      )
      .subscribe(response => {
        this.productsList = response.products;
        this.totalProducts = response.totalProducts;
        this.loading = false;
      });
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;
    this.loadProducts();
  }

  getCategoryName(categoryId: number): string {
    return category[categoryId] || category[category.None]
  };

  filterProducts() {
    this.loadProducts();
  }
  
  isAdmin(): boolean{
    return this.authService.isAdmin();
  }


}

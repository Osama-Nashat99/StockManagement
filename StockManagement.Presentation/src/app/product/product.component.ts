import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/Product.model';
import { NgFor, NgIf } from '@angular/common';
import { category } from '../../enums/category.enum';
import { catchError, finalize, of, Subscription } from 'rxjs';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  productsList: Product[] = [];
  loading: boolean = false;

  constructor(private productService: ProductService){}

  ngOnInit(): void {
    this.loadProducts()
  }

  loadProducts() {
    this.loading = true;

    this.productService.FetchAll().pipe(
                              finalize(() => {
                                this.loading = false; 
                              })
                            ).subscribe(response => {
                              this.productsList = response;
                              this.loading = false;
                            });
  }

  getCategoryName(categoryId: number): string {
    return category[categoryId] || category[category.None]
  };
  


}

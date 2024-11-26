import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/Product.model';
import { NgFor, NgIf } from '@angular/common';
import { category } from '../../enums/category.enum';
import { debounceTime, Subject, switchMap } from 'rxjs';
import { ProductService } from '../../services/product.service';
import { RouterLink } from '@angular/router';
import { MatPaginatorModule, PageEvent,  } from '@angular/material/paginator';
import { ExportToExcelComponent } from '../export-to-excel/export-to-excel.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Filter } from '../../models/Filter.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [NgFor, NgIf, RouterLink, FormsModule, MatPaginatorModule, ExportToExcelComponent],
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
  search: string = '';

  private searchSubject = new Subject<string>();
  private paginationSortSubject = new Subject<void>();

  sortedColumn: string = 'id';
  sortDirection: 'asc' | 'desc' = 'asc';

  constructor(private productService: ProductService, private authService: AuthService, private dialog: MatDialog, private snackBar: MatSnackBar){}

  ngOnInit(): void {

    this.searchSubject.pipe(
      debounceTime(1000),
      switchMap((searchTerm) => {

        this.loading = true;

        const filter: Filter = {
          pageSize: this.pageSize,
          pageNumber: this.currentPage,
          search: searchTerm,
          sortBy: this.sortedColumn,
          sortDirection: this.sortDirection
        };
        return this.productService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.productsList = response.entities;
      this.totalProducts = response.totalEntities;
      this.loading = false
    });

    this.paginationSortSubject.pipe(
      switchMap(() => {

        this.loading = true;

        const filter: Filter = {
          pageSize: this.pageSize,
          pageNumber: this.currentPage,
          search: this.search,
          sortBy: this.sortedColumn,
          sortDirection: this.sortDirection
        };
        return this.productService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.productsList = response.entities;
      this.totalProducts = response.totalEntities;
      this.loading = false
    });

    this.paginationSortSubject.next();
  }

  deleteProduct(id: number, name: string): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Delete Product',
        message: 'Are you sure you want to delete ' + name +'?',
        confirmButtonContent: 'Confirm'
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.productService.deleteProduct(id).subscribe({
          next: () => {
            this.snackBar.open('Product deleted successfuly', 'Done', {
              duration: 3000
            });
            this.paginationSortSubject.next();
          }
        });
      }
    });
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;
    this.paginationSortSubject.next();
  }

  getCategoryName(categoryId: number): string {
    return category[categoryId] || category[category.None]
  };

  filterProducts(event: KeyboardEvent): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.searchSubject.next(inputValue);
  }

  sort(column: string): void {
    if (this.sortedColumn === column) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortedColumn = column;
      this.sortDirection = 'asc';
    }
    this.paginationSortSubject.next();
  }

  isAdmin(): boolean{
    return this.authService.isAdmin();
  }


}

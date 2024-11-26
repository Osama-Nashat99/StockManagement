import { Component } from '@angular/core';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { Filter } from '../../models/Filter.model';
import { debounceTime, Subject, switchMap } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { CategoryService } from '../../services/category.service';
import { Category } from '../../models/Category.model';
import { NgFor, NgIf } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ExportToExcelComponent } from '../export-to-excel/export-to-excel.component';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [NgFor, NgIf, RouterLink, FormsModule, MatPaginatorModule, ExportToExcelComponent],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  categoriesList: Category[] = [];
  loading: boolean = false;
  totalCategories: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  pageSizeOptions: number[] = [5, 10, 25, 50];
  search: string = '';

  private searchSubject = new Subject<string>();
  private paginationSortSubject = new Subject<void>();

  sortedColumn: string = 'id';
  sortDirection: 'asc' | 'desc' = 'asc';

  constructor(private categoriesService: CategoryService, private authService: AuthService, private dialog: MatDialog, private snackBar: MatSnackBar){}

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
        return this.categoriesService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.categoriesList = response.entities;
      this.totalCategories = response.totalEntities;
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
        return this.categoriesService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.categoriesList = response.entities;
      this.totalCategories = response.totalEntities;
      this.loading = false
    });

    this.paginationSortSubject.next();
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;
    this.paginationSortSubject.next();
  }

  filterCategories(event: KeyboardEvent): void {
    const inputValue = (event.target as HTMLInputElement).value;
    this.searchSubject.next(inputValue);
  }

  deleteCategory(id: number, name: string): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Delete Category',
        message: 'Are you sure you want to delete ' + name +'?',
        confirmButtonContent: 'Confirm'
      }
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.categoriesService.deleteCategory(id).subscribe({
          next: () => {
            this.snackBar.open('Category deleted successfuly', 'Done', {
              duration: 3000
            });
            this.paginationSortSubject.next();
          }
        });
      }
    });
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

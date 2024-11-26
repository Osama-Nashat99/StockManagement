import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { RouterLink } from '@angular/router';
import { ExportToExcelComponent } from '../export-to-excel/export-to-excel.component';
import { Store } from '../../models/Store.model';
import { debounceTime, Subject, switchMap } from 'rxjs';
import { StoreService } from '../../services/store.service';
import { AuthService } from '../../services/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Filter } from '../../models/Filter.model';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [NgFor, NgIf, RouterLink, FormsModule, MatPaginatorModule, ExportToExcelComponent],
  templateUrl: './store.component.html',
  styleUrl: './store.component.css'
})
export class StoreComponent implements OnInit {
  storesList: Store[] = [];
  loading: boolean = false;
  totalStores: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  pageSizeOptions: number[] = [5, 10, 25, 50];
  search: string = '';

  private searchSubject = new Subject<string>();
  private paginationSortSubject = new Subject<void>();

  sortedColumn: string = 'id';
  sortDirection: 'asc' | 'desc' = 'asc';

  constructor(private storeService: StoreService, private authService: AuthService, private dialog: MatDialog, private snackBar: MatSnackBar){}

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
        return this.storeService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.storesList = response.entities;
      this.totalStores = response.totalEntities;
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
        return this.storeService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.storesList = response.entities;
      this.totalStores = response.totalEntities;
      this.loading = false
    });

    this.paginationSortSubject.next();
  }

  deleteStore(id: number, name: string): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        title: 'Delete Store',
        message: 'Are you sure you want to delete ' + name +'?',
        confirmButtonContent: 'Confirm'
      }
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.storeService.deleteStore(id).subscribe({
          next: () => {
            this.snackBar.open('Store deleted successfuly', 'Done', {
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

  filterStores(event: KeyboardEvent): void {
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

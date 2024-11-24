import { Component, OnInit } from '@angular/core';
import { debounceTime, Subject, switchMap } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { Filter } from '../../models/Filter.model';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { User } from '../../models/User.model';
import { UserService } from '../../services/user.service';
import { NgFor, NgIf } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ExportToExcelComponent } from '../export-to-excel/export-to-excel.component';
import { Role } from '../../enums/role.enum';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [NgFor, NgIf, RouterLink, FormsModule, MatPaginatorModule, ExportToExcelComponent],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent implements OnInit {

  usersList: User[] = [];
  loading: boolean = false;
  totalUsers: number = 0;
  pageSize: number = 10;
  currentPage: number = 1;
  pageSizeOptions: number[] = [5, 10, 25, 50];
  search: string = '';

  private searchSubject = new Subject<string>();
  private paginationSortSubject = new Subject<void>();

  sortedColumn: string = 'id';
  sortDirection: 'asc' | 'desc' = 'asc';

  constructor(private userService: UserService, private authService: AuthService){}

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
        return this.userService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.usersList = response.users;
      this.totalUsers = response.totalUsers;
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
        return this.userService.fetchAll(filter);
      })
    ).subscribe(response => {
      this.usersList = response.users;
      this.totalUsers = response.totalUsers;
      this.loading = false
    });

    this.paginationSortSubject.next();
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex + 1;
    this.paginationSortSubject.next();
  }

  filterUsers(event: KeyboardEvent): void {
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

  getRoleName(roleValue: number) : string | undefined {
    console.log(roleValue);
    return Role[roleValue];
  }


}

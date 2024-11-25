import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, NgIf],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  isLoggedIn: boolean = false;
  userFullName: string | null = '';

  constructor(private authService: AuthService, private router: Router){}

  isActiveRoute(route: string): boolean {
    return this.router.url === route;
  }
  
  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.userFullName = this.authService.getUserFullName();
  }

  logout(){
    this.authService.logout();
  }

  isAdmin(): boolean{
    return this.authService.isAdmin();
  }
}

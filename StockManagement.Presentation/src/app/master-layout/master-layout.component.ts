import { Component, ElementRef, ViewChild } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-master-layout',
  standalone: true,
  imports: [NgIf ,RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './master-layout.component.html',
  styleUrl: './master-layout.component.css'
})
export class MasterLayoutComponent {
  userFullName: string | null = '';
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router){}

  @ViewChild('sidebar', { static: true }) sidebar!: ElementRef;

  toggleSidebar() {
    this.sidebar.nativeElement.classList.toggle("close");
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

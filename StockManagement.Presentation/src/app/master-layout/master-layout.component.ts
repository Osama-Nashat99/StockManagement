import { Component, ElementRef, ViewChild } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-master-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './master-layout.component.html',
  styleUrl: './master-layout.component.css'
})
export class MasterLayoutComponent {
  userFullName: string = 'Osama Nashat';
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router){}

  @ViewChild('sidebar', { static: true }) sidebar!: ElementRef;

  toggleSidebar() {
    this.sidebar.nativeElement.classList.toggle("close");
  }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  logout(){
    this.authService.logout();
  }
}

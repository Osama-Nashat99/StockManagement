import { Component, ElementRef, ViewChild } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Stock Manager';
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

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
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
  constructor(private authService: AuthService, private router: Router, private activatedRoute: ActivatedRoute){}

  isActiveRoute(route: string): boolean {
    return this.router.url === route;
  }
  
  ngOnInit(): void {
    debugger;
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  logout(){
    this.authService.logout();
  }

  isAdmin(): boolean{
    return this.authService.isAdmin();
  }
}

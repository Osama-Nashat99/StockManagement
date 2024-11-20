import { Component } from '@angular/core';
import { FormControl, ReactiveFormsModule, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [NgIf, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
    
  constructor(private authService: AuthService, private router: Router) {}

  loginForm: FormGroup = new FormGroup({
    username: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required]),
  });

  username = this.loginForm.controls['username'];
  password = this.loginForm.controls['password'];

  onSubmit() {
    this.authService.login(this.username.value, this.password.value).subscribe({
      next: (response) => {
        this.authService.storeToken(response.token);
        this.router.navigate(['/products']);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }
  
}

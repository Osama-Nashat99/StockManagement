import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { HeaderComponent } from '../header/header.component';
import { UserService } from '../../services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '../../services/auth.service';
import { ResetPassword } from '../../models/ResetPassword.model';

@Component({
  selector: 'app-reset-password',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink, HeaderComponent],
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.css'
})
export class ResetPasswordComponent {

  constructor(private userService: UserService, private authService: AuthService, private router: Router, private snackBar: MatSnackBar) {}

  resetPasswordForm: FormGroup = new FormGroup({
    password: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    confirmPassword: new FormControl(null, [Validators.required, Validators.maxLength(100)])
  });

  password = this.resetPasswordForm.controls['password'];
  confirmPassword = this.resetPasswordForm.controls['confirmPassword'];

  onResetPassword(){

    if (this.password.value !== this.confirmPassword.value) {
      this.snackBar.open('Passwords do not match', 'Close', {
        duration: 3000
      });
      return;
    }

    const formValues = this.resetPasswordForm.value;

    var userId = this.authService.getUserId();

    var resetPassword: ResetPassword = {
      id: userId,
      password: formValues.password
    };

    this.userService.resetPassword(userId, resetPassword)
      .subscribe({
        next: () => {
          this.snackBar.open('Password reset successful', 'Close', {
            duration: 3000
          });

          this.authService.logout();   
        }
      });
  }
  
}

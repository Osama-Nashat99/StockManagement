import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, RouterLink } from '@angular/router';
import { HeaderComponent } from '../../header/header.component';
import { UserService } from '../../../services/user.service';
import { Role } from '../../../enums/role.enum';

@Component({
  selector: 'app-user-add',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink, HeaderComponent],
  templateUrl: './users-add.component.html',
  styleUrl: './users-add.component.css'
})
export class UsersAddComponent {
  roles: {value: number, label: String}[] = [];

  constructor(private userService: UserService, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.roles = this.getRoles();
  }

  createUserForm: FormGroup = new FormGroup({
    username: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    firstName: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    lastName: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    role: new FormControl("", [Validators.required]),
  });

  username = this.createUserForm.controls['username'];
  firstName = this.createUserForm.controls['firstName'];
  lastName = this.createUserForm.controls['lastName'];
  role = this.createUserForm.controls['role'];

  onCreateUser(){
    const formValues = this.createUserForm.value;
    formValues.role = parseInt(formValues.role);
    
    this.userService.createUser(formValues)
          .subscribe(user => {
            if (user.id > 0){
              this.snackBar.open('User has been created successfuly', 'Done', {
                duration: 3000
              });

              this.router.navigate(['/users']);
            }
          });
  }

  private getRoles(): {value: number, label: String}[] {
    var rolesArray = [];

    for (const c in Role){
      if (isNaN(Number(c))) {
        rolesArray.push(
          { value: Role[c as keyof typeof Role], label: c }
        );
      }
    };

    return rolesArray;
  }
}

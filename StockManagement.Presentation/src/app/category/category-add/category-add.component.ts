import { Component } from '@angular/core';
import { CategoryService } from '../../../services/category.service';
import { Router, RouterLink } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { HeaderComponent } from '../../header/header.component';

@Component({
  selector: 'app-category-add',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink, HeaderComponent],
  templateUrl: './category-add.component.html',
  styleUrl: './category-add.component.css'
})
export class CategoryAddComponent {

  constructor(private categoryService: CategoryService, private router: Router, private snackBar: MatSnackBar) {}

  createCategoryForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(300)])
  });

  name = this.createCategoryForm.controls['name'];

  onCreateCategory(){
    const formValues = this.createCategoryForm.value;
    
    this.categoryService.createCategory(formValues)
          .subscribe(category => {
            if (category.id > 0){
              this.snackBar.open('Category has been created successfuly', 'Done', {
                duration: 3000
              });

              this.router.navigate(['/categories']);
            }
          });
  }
  
}

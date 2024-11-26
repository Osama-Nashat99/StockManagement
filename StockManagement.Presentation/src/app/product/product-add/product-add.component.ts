import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, RouterLink } from '@angular/router';
import { Product } from '../../../models/Product.model';
import { CategoryService } from '../../../services/category.service';
import { Category } from '../../../models/Category.model';

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent implements OnInit {
  categories: Category[] = [];

  constructor(private productService: ProductService, private categoryService: CategoryService, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.categoryService.getAll()
      .subscribe(categories => { this.categories = categories});
  }

  createProductForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    description: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
    category: new FormControl("", [Validators.required]),
    price: new FormControl(0, [Validators.required, Validators.min(0)]),
    serialNumber: new FormControl("", Validators.maxLength(500))
  });

  name = this.createProductForm.controls['name'];
  category = this.createProductForm.controls['category'];
  description = this.createProductForm.controls['description'];
  price = this.createProductForm.controls['price'];
  serialNumber = this.createProductForm.controls['serialNumber'];

  onCreateProduct(){
    const formValues = this.createProductForm.value;

    debugger;
    var product: Product = {
      id: 0,
      name: formValues.name,
      description: formValues.description,
      categoryId: parseInt(formValues.category),
      categoryName: "",
      price: formValues.price,
      serialNumber: formValues.serialNumber
    };

    this.productService.createProduct(product)
          .subscribe(product => {
            if (product.id > 0){
              this.snackBar.open('Product has been created successfuly', 'Done', {
                duration: 3000
              });

              this.router.navigate(['/products']);
            }
          });
  }
}

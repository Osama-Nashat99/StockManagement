import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { category } from '../../../enums/category.enum';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { Product } from '../../../models/Product.model';
import { MatSnackBar } from '@angular/material/snack-bar'; 

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent implements OnInit {
  categories: {value: number, label: String}[] = [];

  constructor(private productService: ProductService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.categories = this.getCategoryOptions();
  }

  createProductForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    description: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
    category: new FormControl(0),
    price: new FormControl(0, [Validators.required, Validators.min(0)]),
    quantity: new FormControl(0, [Validators.required, Validators.min(0)])
  });

  name = this.createProductForm.controls['name'];
  category = this.createProductForm.controls['category'];
  description = this.createProductForm.controls['description'];
  price = this.createProductForm.controls['price'];
  quantity = this.createProductForm.controls['quantity'];

  resetFormValues(){
    this.createProductForm.reset();
    this.category.setValue(0);
    this.price.setValue(0);
    this.quantity.setValue(0);
  }

  pName: string = this.name.value;
  pDescription: string = this.description.value;
  pCategory: number = this.category.value;
  pPrice: number = this.price.value;
  pQuantity: number = this.quantity.value;

  
  onCreateProduct(){

    const formval = this.createProductForm.value;

    this.productService.createProduct(formval)
          .subscribe(product => {
            if (product.id > 0){
              this.snackBar.open('Product has been created successfuly', 'Done', {
                duration: 3000
              });
            }
          });
  }
  
  private getCategoryOptions(): {value: number, label: String}[] {
    var categoriesArray = [];

    for (const c in category){
      if (isNaN(Number(c))) {
        categoriesArray.push(
          { value: category[c as keyof typeof category], label: c }
        );
      }
    };

    return categoriesArray;
  }
}

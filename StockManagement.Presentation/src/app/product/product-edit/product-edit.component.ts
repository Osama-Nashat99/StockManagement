import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';
import { category } from '../../../enums/category.enum';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HeaderComponent } from '../../header/header.component';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink, HeaderComponent],
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent implements OnInit {
  productId: number = 0;
  categories: {value: number, label: String}[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private productService: ProductService, private snackBar: MatSnackBar){}

  updateProductForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    description: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
    category: new FormControl(0),
    price: new FormControl(0, [Validators.required, Validators.min(0)]),
    quantity: new FormControl(0, [Validators.required, Validators.min(0)])
  });

  name = this.updateProductForm.controls['name'];
  category = this.updateProductForm.controls['category'];
  description = this.updateProductForm.controls['description'];
  price = this.updateProductForm.controls['price'];
  quantity = this.updateProductForm.controls['quantity'];

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];
    this.categories = this.getCategoryOptions();

    this.productService.getProduct(this.productId)
      .subscribe(product => {
        this.name.setValue(product.name);
        this.description.setValue(product.description);
        this.category.setValue(product.category);
        this.price.setValue(product.price);
        this.quantity.setValue(product.quantity);
      })
  }

  onUpdateProduct(){
    const formValues = this.updateProductForm.value;

    formValues.category = parseInt(formValues.category);

    this.productService.updateProduct(this.productId, formValues).subscribe(res => {
      this.snackBar.open('Product has been updated successfuly', 'Done', {
        duration: 3000
      });

      this.router.navigate(['/products']);
    })
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

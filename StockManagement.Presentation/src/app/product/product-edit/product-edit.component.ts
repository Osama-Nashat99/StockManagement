import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HeaderComponent } from '../../header/header.component';
import { Category } from '../../../models/Category.model';
import { CategoryService } from '../../../services/category.service';
import { Product } from '../../../models/Product.model';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink, HeaderComponent],
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent implements OnInit {
  productId: number = 0;
  categories: Category[] = [];

  constructor(private route: ActivatedRoute, private router: Router, private productService: ProductService, private categoryService: CategoryService, private snackBar: MatSnackBar){}

  updateProductForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    description: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
    category: new FormControl("", Validators.required),
    price: new FormControl(0, [Validators.required, Validators.min(0)]),
    serialNumber: new FormControl(null, Validators.maxLength(500))
  });

  name = this.updateProductForm.controls['name'];
  category = this.updateProductForm.controls['category'];
  description = this.updateProductForm.controls['description'];
  price = this.updateProductForm.controls['price'];
  serialNumber = this.updateProductForm.controls['serialNumber'];

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];

    this.categoryService.getAll()
      .subscribe(categories => { this.categories = categories});

    this.productService.getProduct(this.productId)
      .subscribe(product => {
        this.name.setValue(product.name);
        this.description.setValue(product.description);
        this.category.setValue(product.categoryId);
        this.price.setValue(product.price);
        this.serialNumber.setValue(product.serialNumber);
      })
  }

  onUpdateProduct(){
    const formValues = this.updateProductForm.value;

    var product: Product = {
      id: this.productId,
      name: formValues.name,
      description: formValues.description,
      categoryId: parseInt(formValues.category),
      categoryName: "",
      price: formValues.price,
      serialNumber: formValues.serialNumber
    };
    

    this.productService.updateProduct(this.productId, product).subscribe(res => {
      this.snackBar.open('Product has been updated successfuly', 'Done', {
        duration: 3000
      });

      this.router.navigate(['/products']);
    })
  }




}

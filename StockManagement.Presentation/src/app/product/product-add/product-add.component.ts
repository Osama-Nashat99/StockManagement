import { NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, RouterLink } from '@angular/router';
import { Product } from '../../../models/Product.model';
import { CategoryService } from '../../../services/category.service';
import { Category } from '../../../models/Category.model';
import { v4 as uuidv4 } from 'uuid';
import { Store } from '../../../models/Store.model';
import { StoreService } from '../../../services/store.service';
import { ProductStatus } from '../../../enums/productStatus.enum';

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent implements OnInit {
  categories: Category[] = [];
  stores: Store[] = [];
  productStatus: {value: number, label: String}[] = [];
  showIssuedFor: boolean = false;

  constructor(private productService: ProductService, private categoryService: CategoryService, private storeService: StoreService, private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.categoryService.getAll()
      .subscribe(categories => { this.categories = categories});

    this.storeService.getAll()
      .subscribe(stores => {this.stores = stores});

    this.productStatus = this.getProductStatus();

    this.setIssuedForValidation(parseInt(this.status.value));

    this.status.valueChanges.subscribe(value => {
      this.setIssuedForValidation(value);
    })
  }

  createProductForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    description: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
    category: new FormControl("", [Validators.required]),
    price: new FormControl(0, [Validators.required, Validators.min(0)]),
    serialNumber: new FormControl("", Validators.maxLength(500)),
    store: new FormControl("", [Validators.required]),
    status: new FormControl("", [Validators.required]),
    issuedFor: new FormControl(""),
  });

  name = this.createProductForm.controls['name'];
  category = this.createProductForm.controls['category'];
  description = this.createProductForm.controls['description'];
  price = this.createProductForm.controls['price'];
  serialNumber = this.createProductForm.controls['serialNumber'];
  store = this.createProductForm.controls['store'];
  status = this.createProductForm.controls['status'];
  issuedFor = this.createProductForm.controls['issuedFor'];

  onCreateProduct(){
    const formValues = this.createProductForm.value;

    var product: Product = {
      id: 0,
      name: formValues.name,
      description: formValues.description,
      categoryId: parseInt(formValues.category),
      categoryName: "",
      price: formValues.price,
      serialNumber: formValues.serialNumber,
      storeId: parseInt(formValues.store),
      storeName: "",
      status: parseInt(formValues.status),
      issuedFor: formValues.issuedFor
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

  onGenerateUUID(){
    const newGuid = uuidv4();
    this.serialNumber.setValue(newGuid);
  }

  setIssuedForValidation(statusValue: number): void {
    if (statusValue == ProductStatus.Issued) {
      this.showIssuedFor = true;
      this.issuedFor?.setValidators([Validators.required, Validators.maxLength(200)]);
    } else {
      this.showIssuedFor = false;
      this.issuedFor?.removeValidators([Validators.required, Validators.maxLength(200)]);
    }

    this.issuedFor?.updateValueAndValidity();
  }

  private getProductStatus(): {value: number, label: String}[] {
    var statusArray = [];

    for (const s in ProductStatus){
      if (isNaN(Number(s))) {
        statusArray.push(
          { value: ProductStatus[s as keyof typeof ProductStatus], label: s.replaceAll('_', ' ') }
        );
      }
    };

    return statusArray;
  }
}

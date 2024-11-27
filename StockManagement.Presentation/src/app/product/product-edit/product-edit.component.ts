import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Category } from '../../../models/Category.model';
import { CategoryService } from '../../../services/category.service';
import { Product } from '../../../models/Product.model';
import { v4 as uuidv4 } from 'uuid';
import { ProductStatus } from '../../../enums/productStatus.enum';
import { Store } from '../../../models/Store.model';
import { StoreService } from '../../../services/store.service';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, RouterLink],
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent implements OnInit {
  productId: number = 0;
  categories: Category[] = [];
  stores: Store[] = [];
  productStatus: {value: number, label: String}[] = [];
  showIssuedFor: boolean = false;

  constructor(private route: ActivatedRoute, private router: Router, private productService: ProductService, private categoryService: CategoryService, private storeService: StoreService, private snackBar: MatSnackBar){}

  updateProductForm: FormGroup = new FormGroup({
    name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
    description: new FormControl(null, [Validators.required, Validators.maxLength(500)]),
    category: new FormControl("", Validators.required),
    price: new FormControl(0, [Validators.required, Validators.min(0)]),
    serialNumber: new FormControl(null, Validators.maxLength(500)),
    store: new FormControl("", [Validators.required]),
    status: new FormControl("", [Validators.required]),
    issuedFor: new FormControl(""),
  });

  name = this.updateProductForm.controls['name'];
  category = this.updateProductForm.controls['category'];
  description = this.updateProductForm.controls['description'];
  price = this.updateProductForm.controls['price'];
  serialNumber = this.updateProductForm.controls['serialNumber'];
  store = this.updateProductForm.controls['store'];
  status = this.updateProductForm.controls['status'];
  issuedFor = this.updateProductForm.controls['issuedFor'];

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];

    this.categoryService.getAll()
      .subscribe(categories => { this.categories = categories});

    this.storeService.getAll()
      .subscribe(stores => {this.stores = stores});

    this.productStatus = this.getProductStatus();

    this.setIssuedForValidation(parseInt(this.status.value));

    this.status.valueChanges.subscribe(value => {
      this.setIssuedForValidation(value);
    })

    this.productService.getProduct(this.productId)
      .subscribe(product => {
        this.name.setValue(product.name);
        this.description.setValue(product.description);
        this.category.setValue(product.categoryId);
        this.price.setValue(product.price);
        this.serialNumber.setValue(product.serialNumber);
        this.status.setValue(product.status);
        this.store.setValue(product.storeId);
        this.issuedFor.setValue(product.issuedFor)
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
      serialNumber: formValues.serialNumber,
      storeId: parseInt(formValues.store),
      storeName: "",
      status: parseInt(formValues.status),
      issuedFor: formValues.issuedFor
    };


    this.productService.updateProduct(this.productId, product).subscribe(res => {
      this.snackBar.open('Product has been updated successfuly', 'Done', {
        duration: 3000
      });

      this.router.navigate(['/products']);
    })
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

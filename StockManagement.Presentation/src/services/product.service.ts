import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FetchProducts } from '../models/FetchProducts.model';
import { Product } from '../models/Product.model';
import { Filter } from '../models/Filter.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  baseUrl: string = 'https://localhost:7092/api';

  getProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/products/${productId}`);
  }

  fetchAll(filter: Filter): Observable<FetchProducts> {
    return this.http.post<FetchProducts>(`${this.baseUrl}/products/fetch`, filter);
  }

  createProduct(product: Product): Observable<Product> {
    console.log(product)
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    });

    return this.http.post<Product>(`${this.baseUrl}/products`, product, {headers})
  }

  updateProduct(id: number, product: Product) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    });

    return this.http.put<Product>(`${this.baseUrl}/products/${id}`, product, {headers})
  }

  deleteProduct(id: number) {
    return this.http.delete(`${this.baseUrl}/products/${id}`);
  }

}

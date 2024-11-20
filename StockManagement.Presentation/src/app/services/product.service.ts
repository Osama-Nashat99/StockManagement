import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FetchProducts } from '../../models/FetchProducts.model';
import { Product } from '../../models/Product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  baseUrl: string = 'https://localhost:7092/api';

  getProduct(productId: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/products/${productId}`);
  }

  fetchAll(pageNumber: number, pageSize: number, nameFilter?: string, descFilter?: string): Observable<FetchProducts> {

    let params = new HttpParams();

    if (nameFilter) {
      params = params.set('name', nameFilter);
    }

    if (descFilter) {
      params = params.set('description', descFilter);
    }

    params = params.set('pageSize', pageSize.toString());
    params = params.set('pageNumber', pageNumber.toString());

    return this.http.get<FetchProducts>(`${this.baseUrl}/products`, {params});
  }

  createProduct(product: Product): Observable<Product> {

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

}

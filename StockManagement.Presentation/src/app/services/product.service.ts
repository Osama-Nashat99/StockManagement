import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../../models/Product.model';
import { catchError, Observable, of } from 'rxjs';
import { FetchProducts } from '../../models/FetchProducts.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  baseUrl: string = 'https://localhost:7092/api';

  FetchAll(pageNumber: number, pageSize: number): Observable<FetchProducts> {
    return this.http.get<FetchProducts>(`${this.baseUrl}/products?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }
}

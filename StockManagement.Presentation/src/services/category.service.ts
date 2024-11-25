import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Category } from "../models/Category.model";
import { Filter } from "../models/Filter.model";
import { FetchCategories } from "../models/FetchCategories.model";

@Injectable({
    providedIn: 'root'
  })
  export class CategoryService {
  
    constructor(private http: HttpClient) { }
  
    baseUrl: string = 'https://localhost:7092/api';

    fetchAll(filter: Filter): Observable<FetchCategories> {
      return this.http.post<FetchCategories>(`${this.baseUrl}/categories/fetch`, filter);
    }
    
    getAll(): Observable<Category[]> {
      return this.http.get<Category[]>(`${this.baseUrl}/categories`);
    }

    createCategory(category: Category): Observable<Category> {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      });

      return this.http.post<Category>(`${this.baseUrl}/categories`, category, {headers})
    }
    
  }
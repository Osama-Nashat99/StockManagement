import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Category } from "../models/Category.model";

@Injectable({
    providedIn: 'root'
  })
  export class CategoryService {
  
    constructor(private http: HttpClient) { }
  
    baseUrl: string = 'https://localhost:7092/api';

    GetAll(): Observable<Category[]> {
      return this.http.get<Category[]>(`${this.baseUrl}/categories`);
    }
  }
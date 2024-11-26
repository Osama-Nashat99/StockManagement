import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Filter } from "../models/Filter.model";
import { Observable } from "rxjs";
import { FetchStores } from "../models/FetchStores.model";
import { Store } from "../models/Store.model";

@Injectable({
    providedIn: 'root'
})

export class StoreService {
    constructor(private http: HttpClient) { }

    baseUrl: string = 'https://localhost:7092/api';

    getStore(storeId: number): Observable<Store> {
        return this.http.get<Store>(`${this.baseUrl}/stores/${storeId}`);
    }

    getAll(): Observable<Store[]> {
        return this.http.get<Store[]>(`${this.baseUrl}/Stores`);
    }

    fetchAll(filter: Filter): Observable<FetchStores> {
        return this.http.post<FetchStores>(`${this.baseUrl}/stores/fetch`, filter);
    }

    createStore(store: Store): Observable<Store> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });

        return this.http.post<Store>(`${this.baseUrl}/stores`, store, {headers})
    }

    updateStore(id: number, store: Store) {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });

        return this.http.put<Store>(`${this.baseUrl}/stores/${id}`, store, {headers})
    }
    
    deleteStore(id: number) {
        return this.http.delete(`${this.baseUrl}/stores/${id}`);
    }
      
}

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Filter } from "../models/Filter.model";
import { Observable } from "rxjs";
import { FetchUsers } from "../models/FetchUsers.model";
import { User } from "../models/User.model";
import { ResetPassword } from "../models/ResetPassword.model";

@Injectable({
    providedIn: 'root'
  })
  export class UserService {

    constructor(private http: HttpClient) { }

    baseUrl: string = 'https://localhost:7092/api';

    fetchAll(filter: Filter): Observable<FetchUsers> {
      return this.http.post<FetchUsers>(`${this.baseUrl}/users/fetch`, filter);
    }

    createUser(user: User): Observable<User> {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      });

      return this.http.post<User>(`${this.baseUrl}/users`, user, {headers})
    }

    resetPassword(id: number, resetPassword: ResetPassword){
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      });

      return this.http.put<User>(`${this.baseUrl}/users/reset/${id}`, resetPassword, {headers})
    }
  }

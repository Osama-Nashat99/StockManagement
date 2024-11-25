import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { jwtDecode  } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl: string = 'https://localhost:7092/api/auth';
  private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public currentUser: Observable<any> = this.currentUserSubject.asObservable();
  
  constructor(private http: HttpClient, private router: Router) { }

  login(username: string, password: string): Observable<any> {
    const loginPayload = { username, password };

    return this.http.post<any>(this.baseUrl, loginPayload);
  }

  storeTokenAndUserInfo(token: string, fullName: string, userId: string) {
    localStorage.setItem('jwtToken', token);
    localStorage.setItem('uesrFullName', fullName);
    localStorage.setItem("userId", userId);
    this.currentUserSubject.next(token);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  getUserFullName(): string | null {
    return localStorage.getItem('uesrFullName');
  }

  getUserId(): number {
    return parseInt(localStorage.getItem('userId') ?? '0') ;
  }

  logout() {
    localStorage.removeItem('jwtToken');
    localStorage.removeItem('uesrFullName');
    localStorage.removeItem('userId');
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }

  decodeToken(): any {
    const token = this.getToken();
    if (token) {
      return jwtDecode(token);
    }
    return null;
  }

  isAdmin(): boolean {
    const decodedToken = this.decodeToken();
    return decodedToken && decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] === '1';
  }


}

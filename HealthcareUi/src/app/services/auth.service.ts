//Configure Authentication Service

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5000/api/auth';
  private isAuthenticated = new BehaviorSubject<boolean>(this.hasToken());

  constructor(private http: HttpClient, private router: Router) { }

  login(email: string, password: string) {
    return this.http.post<{ token: string }>(`${this.apiUrl}/login`, { email, password }).subscribe(response => {
      localStorage.setItem('token', response.token);
      this.isAuthenticated.next(true);
      this.router.navigate(['/dashboard']);
    });
  }

  logout() {
    localStorage.removeItem('token');
    this.isAuthenticated.next(false);
    this.router.navigate(['/login']);
  }

  isLoggedIn() {
    return this.isAuthenticated.asObservable();
  }

  private hasToken(): boolean {
    return !!localStorage.getItem('token');
  }
}

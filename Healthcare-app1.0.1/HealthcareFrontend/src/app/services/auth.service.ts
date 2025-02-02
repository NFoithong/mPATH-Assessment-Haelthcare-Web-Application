import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  [x: string]: any;
  private baseUrl = 'https://your-backend-url.com/api/auth';

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/login`, { username, password });
  }

  logout() {
    localStorage.removeItem('token');
  }
  isLoggedIn(): boolean {
    // Example: Check if a token exists
    return !!localStorage.getItem('token');
  }

}

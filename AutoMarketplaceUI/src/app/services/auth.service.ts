import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../environments/environment.dev';
import { LoginDto } from '../models/login-dto';
import { RegisterDto } from '../models/registet-dto';
import { GenericApiResponse } from '../models/generic-api-response';
import { User } from '../models/user';

/**
 * Provides authentication-related operations.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly baseUrl = environment.baseUrl;
  private readonly loginUrl = 'api/Auth/login';
  private readonly registerUrl = 'api/Auth/register';

  private tokenSubject = new BehaviorSubject<string | null>(this.getStoredToken());
  authToken$ = this.tokenSubject.asObservable();

  constructor(private httpClient: HttpClient) {}

  /**
   * Logs in a user by sending their credentials to the server.
   * @param loginDto Data Transfer Object containing the user's login credentials (e.g., email and password).
   * @returns Observable containing a GenericApiResponse wrapping a User object if successful.
   */
  login(loginDto: LoginDto): Observable<GenericApiResponse<User>> {
    return new Observable((observer) => {
      this.httpClient.post<GenericApiResponse<User>>(this.baseUrl + this.loginUrl, loginDto)
        .subscribe({
          next: (response) => {
            const token = response.data?.token;
            if (token) {
              this.setAuthToken(token);
            }
            observer.next(response);
            observer.complete();
          },
          error: (err) => observer.error(err),
        });
    });
  }

  /**
   * Registers a new user by sending their details to the server.
   * @param registerDto Data Transfer Object containing the user's registration details (e.g., name, email, and password).
   * @returns Observable containing a GenericApiResponse wrapping a User object if successful.
   */
  register(registerDto: RegisterDto): Observable<GenericApiResponse<User>> {
    return new Observable((observer) => {
      this.httpClient.post<GenericApiResponse<User>>(this.baseUrl + this.registerUrl, registerDto)
        .subscribe({
          next: (response) => {
            const token = response.data?.token;
            if (token) {
              this.setAuthToken(token);
            }
            observer.next(response);
            observer.complete();
          },
          error: (err) => observer.error(err),
        });
    });
  }

  /**
   * Sets the authentication token and notifies subscribers.
   * @param token The token to store in localStorage.
   */
  setAuthToken(token: string | null): void {
    if (token) {
      localStorage.setItem('token', token);
    } else {
      localStorage.removeItem('token');
    }
    this.tokenSubject.next(token);
  }

  /**
   * Clears the authentication token.
   */
  clearAuthToken(): void {
    this.setAuthToken(null);
  }

  /**
   * Retrieves the authentication token from localStorage.
   * @returns The stored token, or null if not present.
   */
  private getStoredToken(): string | null {
    return localStorage.getItem('token');
  }

  /**
   * Returns the current authentication token.
   */
  getAuthToken(): string | null {
    return this.tokenSubject.getValue();
  }
}

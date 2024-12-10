import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.dev';
import { LoginDto } from '../models/login-dto';
import { RegisterDto } from '../models/registet-dto';
import { GenericApiResponse } from '../models/generic-api-response';
import { User } from '../models/user';

/**
 * Provides authentication-related operations.
 */
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly baseUrl = environment.baseUrl;
  private readonly loginUrl = 'api/Auth/login';
  private readonly registerUrl = 'api/Auth/register';

  constructor(private httpClient: HttpClient) {}

  /**
   * Logs in a user by sending their credentials to the server.
   *
   * @param loginDto Data Transfer Object containing the user's login credentials (e.g., email and password).
   * @returns Observable containing a GenericApiResponse wrapping a User object if successful.
   */
  login(loginDto: LoginDto) {
    return this.httpClient.post<GenericApiResponse<User>>(this.baseUrl + this.loginUrl, loginDto);
  }

  /**
   * Registers a new user by sending their details to the server.
   *
   * @param registerDto Data Transfer Object containing the user's registration details (e.g., name, email, and password).
   * @returns Observable containing a GenericApiResponse wrapping a User object if successful.
   */
  register(registerDto: RegisterDto) {
    return this.httpClient.post<RegisterDto>(this.baseUrl + this.registerUrl, registerDto);
  }

  getAuthToken() {
    return localStorage.getItem('token');
  }
}

import { HttpHandlerFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';

/**
 * Interceptor to add the authentication token to the request headers.
 * This function intercepts an outgoing HTTP request, retrieves the authentication token
 * from the AuthService, and appends it to the request headers as a 'Bearer' token.
 * This is typically used for making authenticated API calls that require a token in the headers.
 * @param req - The incoming HTTP request that is being processed by the interceptor.
 * @param next - The HttpHandlerFn used to pass the request to the next handler in the chain.
 * @returns - A modified HTTP request with the 'Authorization' header containing the token.
 */
export function authTokenInterceptor(req: HttpRequest<unknown>, next: HttpHandlerFn) {
  const authToken = inject(AuthService).getAuthToken();

  return authToken ? next(req.clone({setHeaders: {Authorization: `Bearer ${authToken}`}})) : next(req);
}

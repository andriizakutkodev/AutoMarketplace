import { HttpErrorResponse, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { inject } from '@angular/core';
import { NotificationService } from '../services/notification.service';

/**
 * This is an HTTP interceptor that handles error responses from HTTP requests.
 * It listens for HTTP errors, processes the error message, and displays it to the user via the NotificationService.
 * @param req - The HTTP request object that is being sent.
 * @param next - The next HTTP handler function in the chain. It is used to send the request to the server.
 * @returns An observable that emits either the result of the next handler or an error.
 *          If an error occurs, it catches the error, formats the error message,
 *          and shows it via the notification service.
 */
export const errorHandlingInterceptor: HttpInterceptorFn = (req: HttpRequest<unknown>, next: HttpHandlerFn) => {
    const notificationService = inject(NotificationService);

    return next(req).pipe(
        catchError((error: HttpErrorResponse) => {
            const formattedMessage = error.error.message.replace(/\/\//g, '\n');
            notificationService.error(formattedMessage);

            return throwError(() => error);
        })
    );
};

import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

/**
 * Service to display notifications.
 */
@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private config: MatSnackBarConfig = {
    duration: 5000,
    horizontalPosition: 'center',
    verticalPosition: 'top'
  }

  constructor(private matSnackBar: MatSnackBar) {
  }

  /**
   * Displays a success notification with the provided message.
   * @param message - The message to display in the notification.
   */
  success(message: string) {
    this.config['panelClass'] = ['success', 'notification']
    this.matSnackBar.open(message, 'Close', this.config)
  }

  /**
   * Displays an error notification with the provided message.
   * @param message - The message to display in the notification.
   */
  error(message: string) {
    this.config['panelClass'] = ['error', 'notification']
    this.matSnackBar.open(message, 'Close', this.config)
  }
}

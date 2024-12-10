import { FormControl } from '@angular/forms';

/**
 * Describes a login form group.
 */
export interface LoginFormGroup {
  /**
   * The email form control.
   */
  email: FormControl<string>;

  /**
   * The password form control.
   */
  password: FormControl<string>;
}

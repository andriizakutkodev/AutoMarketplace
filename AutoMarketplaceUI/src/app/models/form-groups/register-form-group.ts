import { FormControl } from '@angular/forms';

/**
 * Describes a register form group.
 */
export interface RegisterFormGroup {
  /**
   * The email form control.
   */
  email: FormControl<string>;

  /**
   * The name form control.
   */
  name: FormControl<string>;

  /**
   * The surname form control.
   */
  surname: FormControl<string>;

  /**
   * The phoneNumber form control.
   */
  phoneNumber: FormControl<string>;

  /**
   * The password form control.
   */
  password: FormControl<string>;

  /**
   * The repeatPassword form control.
   */
  repeatPassword: FormControl<string>;
}

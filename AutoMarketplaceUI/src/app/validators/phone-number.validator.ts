import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

const PHONE_REGEX = /^\+?[1-9]\d{1,2}[-.\s]?\(?\d{1,4}\)?[-.\s]?\d{1,9}([-.\s]?\d{1,9})?$/;

export function phoneNumberValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return null;
    }

    const isValid = PHONE_REGEX.test(value);
    return isValid ? null : { invalidPhoneNumber: true };
  };
}

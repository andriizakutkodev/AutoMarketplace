import { AbstractControl, FormControl, ValidationErrors, ValidatorFn } from '@angular/forms';

const PASSWORD_CONTROL_NAME = 'password';
const REPEAT_PASSWORD_CONTROL_NAME = 'repeatPassword';

export function passwordsMatchValidator(): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const password = formGroup.get(PASSWORD_CONTROL_NAME) as FormControl;
    const repeatPassword = formGroup.get(REPEAT_PASSWORD_CONTROL_NAME) as FormControl;

    if (!password || !repeatPassword) {
      return null;
    }

    const passwordValue = password.value;
    const repeatPasswordValue = repeatPassword.value;

    if (!passwordValue || !repeatPasswordValue) {
      if (password.errors) {
        const { passwordsMismatch, ...otherErrors } = password.errors;
        password.setErrors(Object.keys(otherErrors).length > 0 ? otherErrors : null);
      }
      if (repeatPassword.errors) {
        const { passwordsMismatch, ...otherErrors } = repeatPassword.errors;
        repeatPassword.setErrors(Object.keys(otherErrors).length > 0 ? otherErrors : null);
      }
      return null;
    }

    const isMatch = passwordValue === repeatPasswordValue;

    if (!isMatch) {
      password.setErrors({ ...password.errors, passwordsMismatch: true });
      repeatPassword.setErrors({ ...repeatPassword.errors, passwordsMismatch: true });
    } else {
      if (password.errors) {
        const { passwordsMismatch, ...otherErrors } = password.errors;
        password.setErrors(Object.keys(otherErrors).length > 0 ? otherErrors : null);
      }
      if (repeatPassword.errors) {
        const { passwordsMismatch, ...otherErrors } = repeatPassword.errors;
        repeatPassword.setErrors(Object.keys(otherErrors).length > 0 ? otherErrors : null);
      }
    }

    return null;
  };
}

import { Component } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader } from '@angular/material/card';
import { MatError, MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { RegisterFormGroup } from '../../models/form-groups/register-form-group';
import { phoneNumberValidator } from '../../validators/phone-number.validator';
import { passwordsMatchValidator } from '../../validators/password-match.validator';

@Component({
  selector: 'app-register',
  imports: [
    FormsModule,
    MatButton,
    MatCard,
    MatCardActions,
    MatCardContent,
    MatCardHeader,
    MatError,
    MatFormField,
    MatInput,
    MatLabel,
    ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  registerForm: FormGroup;

  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) {
    this.registerForm = this.formBuilder.group<RegisterFormGroup>({
      email: new FormControl('', [Validators.required, Validators.email]),
      name: new FormControl('', [Validators.required]),
      surname: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required, phoneNumberValidator()]),
      password: new FormControl('', [Validators.required]),
      repeatPassword: new FormControl('', [Validators.required]),
    } as RegisterFormGroup, { validators: passwordsMatchValidator() });
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(response => {
      if (response.isSuccess) {
        this.router.navigate(['']);
      }
    });
  }

  hasError(control: AbstractControl, errorName: string): boolean {
    return control.hasError(errorName);
  }

  isRegisterButtonDisabled() {
    return this.registerForm.invalid;
  }

  hasPasswordsMismatchError() {
    console.log(this.registerForm.errors?.['passwordsMismatch']);

    return this.registerForm.errors?.['passwordsMismatch'];
  }
}

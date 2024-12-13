import { Component } from '@angular/core';
import { MatCard, MatCardActions, MatCardContent, MatCardHeader } from '@angular/material/card';
import { MatButton } from '@angular/material/button';
import {MatError, MatFormField, MatLabel} from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { LoginFormGroup } from '../../models/form-groups/login-form-group';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [
    MatCard,
    MatCardHeader,
    MatCardContent,
    MatCardActions,
    MatButton,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatError
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) {
    this.loginForm = this.formBuilder.group<LoginFormGroup>({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    } as LoginFormGroup);
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe(response => {
      if (response.isSuccess) {
        this.router.navigate(['']);
      }
    });
  }

  hasError(control: AbstractControl, errorName: string): boolean {
    return control.hasError(errorName);
  }

  isLoginButtonDisabled() {
    return this.loginForm.invalid;
  }

  onRegisterClick() {
    this.router.navigate(['register']);
  }
}

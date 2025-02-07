import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      this.errorMessage = 'Invalid username or password format.';
      return;
    }

    this.authService.login(this.loginForm.value.username, this.loginForm.value.password)
      .subscribe({
        next: (response) => {
          localStorage.setItem('token', response.token);  // Store JWT securely
          this.router.navigate(['/dashboard']);
        },
        error: (err) => {
          this.errorMessage = 'Login failed. Check your credentials.';
        }
      });
  }
}

import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { SessionRequest } from 'src/app/models/session-models/SessionRequest';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({});
  public sessionRequest: SessionRequest = new SessionRequest();
  constructor(
    private formBuilder: FormBuilder,
    public snackBarService: SnackBarService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.buildForm();
  }

  private buildForm(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  public login(): void {
    this.authService.login(this.sessionRequest).subscribe(
      (response) => {
        this.snackBarService.successMessage(
          'Bienvenido a Clothes Store',
          'Aceptar'
        );
        this.router.navigate(['/products']);
        let decodedJWT = JSON.parse(window.atob(response.split('.')[1]));
        const decodedRole =
          decodedJWT[
            'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
          ];
        console.log(decodedRole);
        localStorage.setItem('userRol', decodedRole);
      },
      (error) => {
        console.log(error);
        this.snackBarService.errorMessage(
          'Ocurrio un error, verifique su usuario y contraseña',
          'Aceptar'
        );
      }
    );
  }
}

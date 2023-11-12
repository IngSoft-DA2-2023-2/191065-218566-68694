import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { SnackBarService } from 'src/app/services/snack-bar.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  menuItems = [
    { icon: 'shopping_basket', title: 'Productos', route: '' },
    { icon: 'receipt', title: 'Ordenes de compra', route: '' },
    { icon: 'person', title: 'Usuarios', route: '' },
  ];
  constructor(
    public authService: AuthService,
    private router: Router,
    private snackBarService: SnackBarService
  ) {}

  public logout(): void {
    this.authService.logout().subscribe(
      (response) => {
        this.router.navigate(['/login']);
      },
      (error) => {
        this.snackBarService.errorMessage(
          'Ocurrio un error  y no se pudo cerrar sesión',
          'Aceptar'
        );
      }
    );
  }
}

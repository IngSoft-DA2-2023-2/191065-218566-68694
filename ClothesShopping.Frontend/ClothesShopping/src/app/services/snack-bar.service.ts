import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackBarService {
  constructor(private snackBar: MatSnackBar) {}

  public successMessage(contenido: any, accion: any): void {
    let sb = this.snackBar.open(contenido, accion, {
      duration: 5000,
      panelClass: ['snackbarStyleSuccess'],
    });
    sb.onAction().subscribe(() => {
      sb.dismiss();
    });
  }

  public errorMessage(contenido: any, accion: any): void {
    let sb = this.snackBar.open(contenido, accion, {
      duration: 5000,
      panelClass: ['snackbarStyleWarn'],
    });
    sb.onAction().subscribe(() => {
      sb.dismiss();
    });
  }
}
